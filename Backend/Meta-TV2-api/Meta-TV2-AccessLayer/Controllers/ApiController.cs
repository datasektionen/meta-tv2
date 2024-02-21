namespace Meta_TV2_api.Controllers;

using Meta_TV2_BusinessLayer;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/dbinput")]
public class TestApiRoute : ControllerBase 
{
    IBusinessRules businessRules = new BusinessRules();
    /*
    Example JSON for this method:

    {
    "title": "testtitle",
    "priority": false,
    "hidden": false,
    "createdBy": "dannik",
    "startDate": "2024-02-15T18:21:00",
    "endDate": "2024-02-20T12:00:00",
    "archive": false,
    "archiveDate": null
    }
    */
    
}

[Route("[controller]")]
public class Group : ControllerBase
{
    IBusinessRules businessRules = new BusinessRules();
    
    [HttpPost]
    public IActionResult AddGroup(string GroupObject){
        var add = businessRules.AddGroup(GroupObject);
        return add ? Ok() : BadRequest("Failed to add group.");
    }

    [HttpGet]   
    public IActionResult GetGroups(){
        var groups = businessRules.GetGroupsTest();
        return groups != null ? Ok(groups) : NotFound("No groups found");
    }

    //Create a route for /Group/page=1&size=10
    [HttpGet("page={page}&size={size}")]
    public IActionResult GetGroupsByPage(int page, int size)
    {
        var groups = businessRules.GetGroups(page, size);
        return groups != null ? Ok(groups) : NotFound("No groups found");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGroupById(int id) 
    {
        var group = await businessRules.GetGroupById(id); 
        return group != null ? Ok(group) : NotFound($"Group based on ID: {id} not found"); 
    }

    // [HttpDelete("{id}")]
    // public IActionResult DeleteGroup(int id)
    // {
    //     var delete = businessRules.ArchiveGroup(id);
    //     return delete ? Ok() : NotFound($"Group based on ID: {id} not found");
    // }
}
