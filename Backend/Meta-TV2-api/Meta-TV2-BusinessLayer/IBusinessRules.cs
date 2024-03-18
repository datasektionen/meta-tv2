using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

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

}
