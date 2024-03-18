namespace Meta_TV2_DataLayer;

public interface IDataAccess
{


    /// <summary>
    /// Test method for adding to the "Groups" table.
    /// </summary>
    /// <param name="group">Groups object to add</param>
    public void AddGroups(Groups group);


    /// <summary>
    /// Test method for adding to the "Blacklist" table.
    /// </summary>
    /// <param name="blacklist">Blacklist object to add</param>
    public void Test_AddBlacklist(Blacklist blacklist);

    /// <summary>
    /// Function to retrive all groups that are not archived.
    /// </summary>
    /// <returns>Groups not archived</returns>
    public Task<List<Groups>> GetGroups();

    /// <summary>
    /// Function to get a group by id, that is not archived
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Optional<Groups>> GetGroupById(int id);

    /// <summary>
    /// Function to arhieve a group, takes in a group object
    /// </summary>
    /// <param name="group"></param>
    public void ArchiveGroup(Groups group);

    /// <summary>
    /// Gets groups based on page and size, thare are not archived. size decides how many objects to return, page decides which set of objects to return. 
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public Task<Optional<List<Groups>>> GetGroups(int page, int size);



}
