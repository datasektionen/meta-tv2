namespace Meta_TV2_BusinessLayer;

public interface IBusinessRules
{
    /// <summary>
    /// Deserializes a Group JSON object and adds the deserialized Group object to database by invoking datalayer
    /// </summary>
    /// <param name="groupObject">Group JSON object</param>
    /// <returns>True if successfull otherwise false</returns>
    public Task<bool> AddGroup(string groupObject);

    /// <summary>
    /// Gets groups (non-archived) by invoking datalayer and serializing Group objects to JSON object
    /// </summary>
    /// <returns>Group JSON object if any groups were found, othwerwise null</returns>
    public Task<string> GetGroups();

    /// <summary>
    /// Gets group (including archived) by id by invoking datalayer and serializes Group object to JSON object
    /// </summary>
    /// <param name="id">Group Id in database</param>
    /// <returns>Group JSON object if any group was found, othwerwise null</returns>
    public Task<string> GetGroupById(int id);

    /// <summary>
    /// Archives group in database by updating Group object attributes and invokes datalayer
    /// </summary>
    /// <param name="id">Id of group to archive</param>
    /// <returns>True if successfull otherwise false</returns>
    public Task<bool> ArchiveGroup(int id);

    /// <summary>
    /// Gets groups (non-archived) by pagination by invoking datalayer and serializing Group objects to JSON object
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns>JSON serialized list of groups if found, otherwise null</returns>
    public Task<string> GetGroups(int page, int size);

}
