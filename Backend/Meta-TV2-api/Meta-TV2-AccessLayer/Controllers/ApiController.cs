namespace Meta_TV2_api.Controllers;

using Meta_TV2_BusinessLayer;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class Group : ControllerBase
{
    IBusinessRules businessRules = new BusinessRules();
    
    [HttpPost]
    public async Task<IActionResult> AddGroup(string GroupObject){
        var add = await businessRules.AddGroup(GroupObject);
        return add ? Ok() : BadRequest("Failed to add group.");
    }

    [HttpGet]
    public async Task<IActionResult> GetGroups(){
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
public class Slide : ControllerBase {
    IBusinessRules businessRules = new BusinessRules();

    [HttpGet]
    public async Task<IActionResult> GetSlides() {
        var slides = await businessRules.GetSlides();
        return slides != null ? Ok(slides) : NotFound("No slides found");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSlidesByGroup(int id) {
        var slides = await businessRules.GetSlidesByGroup(id);
        return slides != null ? Ok(slides) : NotFound($"No slides found for group id; {id}");
    }

    [HttpGet("{id}/page={page}&size={size}")]
    public async Task<IActionResult> GetSlidesByGroupPage(int id, int page, int size) {
        var slides = await businessRules.GetSlidesByGroup(id, page, size);
        return slides != null ? Ok(slides) : NotFound($"No slides found for group id: {id}");
    }

    [HttpPost]
    public async Task<IActionResult> AddSlide(string slideObject) {
        var created = await businessRules.AddSlide(slideObject);
        return created ? Ok() : BadRequest("Failed to add Slide");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ArchiveSlide(int id) {
        var delete = await businessRules.ArchiveSlide(id);
        return delete ? Ok() : BadRequest($"Failed to remove slide: {id}");
    }
}