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
    [HttpPost]
    public IActionResult Test_AddGroups(string GroupObject){
        var add = businessRules.Test_AddGroups(GroupObject);
        return add ? Ok() : BadRequest();
    }
}