namespace Meta_TV2_api.Controllers;

using Meta_TV2_BusinessLayer;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class Group : ControllerBase
{
    IBusinessRules businessRules = new BusinessRules();
    
    [HttpPost]
    public async Task<IActionResult> AddGroup(string GroupObject)
    {
        var add = await businessRules.AddGroup(GroupObject);
        return add ? Ok() : BadRequest("Failed to add group.");
    }

    [HttpGet]
    public async Task<IActionResult> GetGroups()
    {
        var groups = await businessRules.GetGroups();
        return groups != null ? Ok(groups) : NotFound("No groups found");
    }

    [HttpGet("page={page}&size={size}")]
    public async Task<IActionResult> GetGroupsByPage(int page, int size)
    {
        var groups = await businessRules.GetGroups(page, size);
        return groups != null ? Ok(groups) : NotFound("No groups found");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGroupById(int id) 
    {
        var group = await businessRules.GetGroupById(id);
        return group != null ? Ok(group) : NotFound($"No result for groupId {id}"); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSlidesByGroup(int id)
    {
        var slides = await businessRules.GetSlidesByGroup(id);
        return slides != null ? Ok(slides) : NotFound($"No slides found for group id; {id}");
    }

    [HttpGet("{id}/page={page}&size={size}")]
    public async Task<IActionResult> GetSlidesByGroupPage(int id, int page, int size)
    {
        var slides = await businessRules.GetSlidesByGroup(id, page, size);
        return slides != null ? Ok(slides) : NotFound($"No slides found for group id: {id}");
    }

    [HttpPost]
    public async Task<IActionResult> AddSlide(string slideObject)
    {
        var created = await businessRules.AddSlide(slideObject);
        return created ? Ok() : BadRequest("Failed to add Slide");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ArchiveSlide(int id)
    {
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
        var posts = await businessRules.GetPosts(id);
        return posts != null ? Ok(posts) : BadRequest($"No posts found for id: {id}"); 
    }

    [HttpPost]
    public async Task<IActionResult> AddPost(string post, IFormFile[] file) {
        if(await businessRules.AddPostWithUrl(post))
            return Ok("Post has been added");
        if (file == null || file.Length == 0)
            return BadRequest("File missing for post");

        foreach (var item in file) {
            var pathWithIdentifier = await businessRules.AddPostWithFile(post, item.ContentType.Split("/")[1]);
            if(pathWithIdentifier == null)
                return BadRequest("Failed to add post");
                
            var completePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", pathWithIdentifier + "." + item.ContentType.Split("/")[1]);
            using (var stream = new FileStream(completePath, FileMode.Create)) {
                await item.CopyToAsync(stream);
            }
        }
        return Ok("Post has been added");
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