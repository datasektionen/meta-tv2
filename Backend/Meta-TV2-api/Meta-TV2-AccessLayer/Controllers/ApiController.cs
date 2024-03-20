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

    //Create a route for /Group/page=1&size=10
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
