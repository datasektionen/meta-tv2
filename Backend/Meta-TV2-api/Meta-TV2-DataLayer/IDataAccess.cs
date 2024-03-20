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

    /// <summary>
    /// Gets all non-archived slides from database (in database order)
    /// </summary>
    /// <returns>Optional object with a list of Slide objects as value, otherwise empty Optional object if no slides found</returns>
    public Task<Optional<List<Slides>>> GetSlides();

    /// <summary>
    /// Gets all non-archived slides associated with a specific group Id from the database (in database order)
    /// </summary>
    /// <param name="groupId">the group Id to filter slides on</param>
    /// <returns>Optional object with a list of Slide objects as value, otherwise empty Optional object if no slides found</returns>
    public Task<Optional<List<Slides>>> GetSlidesByGroup(int groupId);

    /// <summary>
    /// Gets a specific slide associated with a specific slide Id from the databse (ignores if the slide is archived or not)
    /// </summary>
    /// <param name="id">the slide Id to filter against</param>
    /// <returns>Optional object with a slide object, otherwise empty Optional object if no slide was found</returns>
    public Task<Optional<Slides>> GetSlideById(int id);

    /// <summary>
    /// Gets all non-archived slides associated with a specific group Id, page and size from the database.
    /// The size determines how many slides to return, and page determines which set of slides to return.
    /// Page is 1 indexed.
    /// </summary>
    /// <param name="groupId">the group Id to filter slides on</param>
    /// <param name="page">which set of result to return</param>
    /// <param name="size">the size of the result</param>
    /// <returns>Optional object witha list of slide objects as value, otherwise empty Optional object if no slides found</returns>
    public Task<Optional<List<Slides>>> GetSlidesByGroup(int groupId, int page, int size);

    /// <summary>
    /// Creates a new Slide and stores the Slide inside the database.
    /// </summary>
    /// <param name="obj">The slide object to store</param>
    public void AddSlide(Slides obj);

    /// <summary>
    /// Updates an already existing slide in the databse and stores the update.
    /// Will update the slide with the given attributes based on the slideId.
    /// </summary>
    /// <param name="slide">The updated slide to store</param>
    public void UpdateSlide(Slides slide);
}
