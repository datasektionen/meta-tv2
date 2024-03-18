namespace Meta_TV2_DataLayer;

public interface IDataAccess
{


    /// <summary>
    /// Method to add groups, will be added to the database.
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
    /// Function to get a group by id, the id corresponds to the group id stored in the database to fetch.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Optional<Groups>> GetGroupById(int id);

    /// <summary>
    /// Function to archive a group, takes in a group object. Group will not be deleted, only archieved. 
    /// </summary>
    /// <param name="group"></param>
    public void ArchiveGroup(Groups group);

    /// <summary>
    /// Gets groups based on page and size, that are not archived. size decides how many objects to return, page decides which set of objects to return. 
    /// For exampe page = 1 & size=3 will get the 3 first groups, page=2 & size=3 will groups 4-6.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public Task<Optional<List<Groups>>> GetGroups(int page, int size);

    public Task<Optional<List<Slides>>> GetSlides();

    public Task<Optional<List<Slides>>> GetSlidesByGroup(int groupId);

    public Task<Optional<Slides>> GetSlideById(int id);

    public Task<Optional<List<Slides>>> GetSlidesByGroup(int groupId, int page, int size);

    public Task<bool> CreateSlide(Slides obj);

    public void UpdateSlide(Slides slide);


}
