namespace Meta_TV2_api.Controllers;

using Meta_TV2_BusinessLayer;
using Meta_TV2_DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class JwtToken : ControllerBase 
{
    private static IConfiguration _config;
    public JwtToken(IConfiguration config)
    {
        _config = config;
    }
    IKthAuth kthAuth = new KthAuth();
    IBusinessRules businessRules = new BusinessRules();

    // This method will be invoked trough callback with the DsektToken after successfully logging in.
    [HttpPost("IssueNewToken")]
    public async Task<IActionResult> IssueNewToken([FromQuery] string DsektToken){
        var user = await kthAuth.VerifyToken(DsektToken);           // Verify that the token is valid and recieve user
        if (user == null) {
            return BadRequest($"The given token was not valid. Token: {DsektToken}");
        }
        
        var isBlacklisted = await businessRules.GetBlacklistByAlias(user);
        if (isBlacklisted == null){
            return BadRequest("Was not able to fetch if user is blacklisted");
        }
        else if (isBlacklisted.HasValue){
            return StatusCode(StatusCodes.Status403Forbidden, "You are not allowed to log in");
        }

        IJwtRules jwtRules = new JwtRules(_config["Jwt:Issuer"],
            _config["Jwt:Key"],
            await kthAuth.IsAdmin(user),
            DsektToken);
        //TODO send username to client
        return Ok(jwtRules.IssueNewToken(20));                   // Issue 20 minute valid token    
    }
}

[Route("[controller]")]
public class Group : ControllerBase
{
    IBusinessRules businessRules = new BusinessRules();

    [Authorize]
    [HttpPost]
    public IActionResult AddGroup([FromBody] Groups GroupObject){
        var add = businessRules.AddGroup(GroupObject);
        return add ? Ok() : BadRequest("Failed to add group.");
    }

    [HttpGet]
    public async Task<IActionResult> GetGroups()
    {
        var groups = await businessRules.GetGroups();
        return groups != null ? Ok(groups) : NotFound("No groups found");
    }

    [HttpGet("pages")]
    public async Task<IActionResult> GetGroupsByPage([FromQuery] int page, int size){
        var groups = await businessRules.GetGroups(page, size);
        return groups != null ? Ok(groups) : NotFound("No groups found");
    }

    [Authorize]
    [HttpGet("id")]
    public async Task<IActionResult> GetGroupById([FromQuery] int id){
        var group = await businessRules.GetGroupById(id);
        return group != null ? Ok(group) : NotFound($"No result for groupId {id}"); 
    }

    [Authorize]
    [HttpDelete("id")]
    public async Task<IActionResult> DeleteGroup([FromQuery] int id){
        var delete = await businessRules.ArchiveGroup(id);
        return delete ? Ok() : NotFound($"Group based on ID: {id} not found");
    }
}

[Route("[Controller]")]
public class Slide : ControllerBase 
{
    IBusinessRules businessRules = new BusinessRules();

    [HttpGet]
    public async Task<IActionResult> GetSlides()
    {
        var slides = await businessRules.GetSlides();
        return slides != null ? Ok(slides) : NotFound("No slides found");
    }
    [HttpGet("GroupId")]
    public async Task<IActionResult> GetSlidesByGroup([FromQuery] int id) {
        var slides = await businessRules.GetSlidesByGroup(id);
        return slides != null ? Ok(slides) : NotFound($"No slides found for group id; {id}");
    }

    [HttpGet("pages")]
    public async Task<IActionResult> GetSlidesByGroupPage([FromQuery] int id, int page, int size) {
        var slides = await businessRules.GetSlidesByGroup(id, page, size);
        return slides != null ? Ok(slides) : NotFound($"No slides found for group id: {id}");
    }

    [HttpPost]
    public IActionResult AddSlide([FromBody] Slides slideObject) {
        var created = businessRules.AddSlide(slideObject);
        return created ? Ok() : BadRequest("Failed to add Slide");
    }

    [HttpDelete("id")]
    public async Task<IActionResult> ArchiveSlide([FromQuery] int id) {
        var delete = await businessRules.ArchiveSlide(id);
        return delete ? Ok() : BadRequest($"Failed to remove slide: {id}");
    }
}

[Route("[controller]")]
public class Post : ControllerBase
{
    IBusinessRules businessRules = new BusinessRules();

    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var posts = await businessRules.GetPosts();
        return posts != null ? Ok(posts) : BadRequest("No posts found"); 
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPosts(int id)
    {
        //Get post by id
        var posts = await businessRules.GetPosts(id);
        return posts != null ? Ok(posts) : BadRequest($"No posts found for id: {id}"); 
    }

    [HttpPost]
    public async Task<IActionResult> AddPost(string post, IFormFile file)
    {
        // Convert IFormFile to ICustomFormFile
        ICustomFormFile customFile = new FormFileWrapper(file);

        var added = await businessRules.AddPost(post, customFile);
        return added ? Ok() : BadRequest("Failed to add post");
    }
    [HttpGet("{id}/file")]

    public async Task<IActionResult> GetPostFile(int id)
    {
        var (folder, fileType) = await businessRules.GetPostFileType(id);
        if (folder == null)
        {
            return NotFound($"Post with id: {id} doesn't exist");
        }
        if (folder == "Url")
        {
            return Ok(fileType);
        }
        try
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder, id.ToString() + fileType);
            var file = System.IO.File.OpenRead(path);
            return folder switch
            {
                "Image" => File(file, "image/" + fileType.Split(".")[1]),
                "Video" => File(file, "video/" + fileType.Split(".")[1]),
                "Html" => File(file, "text/html"),
                _ => BadRequest("Something went wrong")
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest("Something went wrong");
        }
    }
}
[Authorize(Roles = "Admin")]
[Route("[Controller]")]
public class Admin : ControllerBase {
    IBusinessRules businessRules = new BusinessRules();
    
    [HttpPost("banUser")]
    public IActionResult BanUser([FromQuery] string alias) {
        var created = businessRules.BanUser(alias);
        return created ? Ok() : BadRequest("Failed to ban user!");
    }

    [HttpGet("information")]
    public async Task<IActionResult> GetAdminInformation() {
        var BlacklistedUsers = await businessRules.GetBlacklistedUsers();
        // TODO: add amount of tv-information
        return BlacklistedUsers != null ? Ok(BlacklistedUsers) : StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete("unban")]
    public async Task<IActionResult> UnbanUser([FromQuery] string alias) {
        var delete = await businessRules.UnbanUser(alias);
        return delete ? Ok() : BadRequest($"Failed to unban user: {alias}");
    }   
}