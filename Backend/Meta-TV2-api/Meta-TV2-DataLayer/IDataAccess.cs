namespace Meta_TV2_DataLayer;

public interface IDataAccess
{
    /// <summary>
    /// Adds Group object to database
    /// </summary>
    /// <param name="group">Group object to be added</param>
    public void AddGroups(Groups group);

    /// <summary>
    /// Gets all non-archived groups from database (in database order)
    /// </summary>
    /// <returns>Optional object with a list of Group objects as value, otherwise empty Optional object if no groups found</returns>
    public Task<Optional<List<Groups>>> GetGroups();

    /// <summary>
    /// Gets group (including archived) from database by Id
    /// </summary>
    /// <param name="id">Group Id in database</param>
    /// <returns>Optional object with the Group object as value, otherwise empty Optional object if no group found</returns>
    public Task<Optional<Groups>> GetGroupById(int id);

    /// <summary>
    /// Updates group entry in database to new Group object based on Id
    /// </summary>
    /// <param name="group">Group object with updated attributes</param>
    public void UpdateGroup(Groups group);

    /// <summary>
    /// Gets groups (non-archived) by pagination (in database order)
    /// </summary>
    /// <param name="size">Determines number of groups per page</param>
    /// <param name="page">Determines which chunk of groups to get</param>
    /// <returns>Optional object with a list of Group objects as value, otherwise empty Optional object if no groups found</returns>
    public Task<Optional<List<Groups>>> GetGroups(int size, int page);



}
