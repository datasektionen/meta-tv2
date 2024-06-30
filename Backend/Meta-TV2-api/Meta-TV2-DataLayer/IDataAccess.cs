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
    /// <param name="page">Determines which chunk of groups to get</param>
    /// <param name="size">Determines number of groups per page</param>
    /// <returns>Optional object with a list of Group objects as value, otherwise empty Optional object if no groups found</returns>
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
    public void AddSlide(Slides slide);

    /// <summary>
    /// Updates an already existing slide in the databse and stores the update.
    /// Will update the slide with the given attributes based on the slideId.
    /// </summary>
    /// <param name="slide">The updated slide to store</param>
    public void UpdateSlide(Slides slide);

    /// <summary>
    /// Stores a the given Blacklist obj into the database.
    /// </summary>
    /// <param name="obj">The Blacklist object to store</param>
    public void AddBlacklist(Blacklist obj);

    /// <summary>
    /// Gets all blacklisted users from database (in database order)
    /// </summary>
    /// <returns>Optional object with a list of Blacklisted objects as value, otherwise empty Optional object if no blacklisted users</returns>
    public Task<Optional<List<Blacklist>>> GetBlacklistedUsers();

    /// <summary>
    /// Get the Blacklist object with the specified alias
    /// </summary>
    /// <returns>Optional object with the Blacklist object, otherwise empty Optional object if such Blacklisted alias does not exists</returns>
    /// <param name="alias"> The alias to search for</param>
    public Task<Optional<Blacklist>> GetBlacklistByAlias(string alias);
    
    /// <summary>
    /// Removes the Blacklist object from the database
    /// </summary>
    /// <param name="obj">The object to delete from the database</param>
    public void RemoveFromBlacklist(Blacklist obj);
}
