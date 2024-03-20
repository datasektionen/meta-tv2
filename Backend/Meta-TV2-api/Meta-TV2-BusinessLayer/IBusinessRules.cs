using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Meta_TV2_DataLayer;

namespace Meta_TV2_BusinessLayer;

public interface IBusinessRules
{
    /// <summary>
    /// A function that will invoke AddGroup function from the dataLayer
    /// </summary>
    /// <param name="groupObject"></param>
    /// <returns>will return true/false if the operation was sucessfull or not.</returns>
    public Task<bool> AddGroup(string groupObject);

    /// <summary>
    /// A function that will invoke GetGroups function from the dataLayer, 
    /// </summary>
    /// <returns>will return a JSON serialized list of groups if any was found, otherwise null.</returns>
    public Task<string> GetGroups();

    /// <summary>
    /// Same as getGroups, but will return a single group based on the group id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>JSON serialized group object if found, or null if not found</returns>
    public Task<string> GetGroupById(int id);

    /// <summary>
    /// Will invoke ArchieveGroup from datalayer, will change archieved attribute to true. 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Will return true if successfull otherwise false</returns>
    public Task<bool> ArchiveGroup(int id);

    /// <summary>
    /// Will invoke getGroups(page, size) from datalyer
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns>JSON serialized list of groups if found, otherwise null</returns>
    public Task<string> GetGroups(int page, int size);

    /// <summary>
    /// Gets slides (non-archived) from the database by invoking datalayer and serializing result to JSON object.
    /// </summary>
    /// <returns>Slide JSON object if any groups were found, otherwise null</returns>
    public Task<string> GetSlides();

    /// <summary>
    /// Gets all slides (non-archived) associated with a specific group Id by invoking datalayer and serializing result to JSON object.
    /// </summary>
    /// <param name="groupId">The group Id to filter on</param>
    /// <returns>Slide JSON object if any slides were found, otherwise null</returns>
    public Task<string> GetSlidesByGroup(int groupId);
    /// <summary>
    /// Gets a specific slide (can be archived) associated with a specific slide Id by invoking datalayer and serializing result to JSON object.
    /// </summary>
    /// <param name="id">the slide Id to filter on</param>
    /// <returns>Slide JSON object if any slide were found, otherwise null</returns>
    public Task<string> GetSlideById(int id);

    /// <summary>
    /// Gets slides (non-archived) by pagination by invoking datalayer and serializing result to JSON object
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns>Slide JSON object if any slide were found, otherwise null<</returns>
    public Task<string> GetSlidesByGroup(int groupId, int page, int size);

    /// <summary>
    /// Deserializes a Slide JSON object and adds the desralized object to the database by invoking datalayer.
    /// </summary>
    /// <param name="slideObject">Slide JSON object</param>
    /// <returns>True if operation successfull otherwise false</returns>
    public Task<bool> CreateSlide(string slideObject);

    /// <summary>
    /// Archives a specific slide in the database by updating slide archived field and invoking datalayer.
    /// </summary>
    /// <param name="id">The id of the slide to archive</param>
    /// <returns>True if operation was successfull otherwise false.</returns>
    public Task<bool> ArchiveSlide(int id);

}
