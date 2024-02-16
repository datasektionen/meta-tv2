namespace Meta_TV2_DataLayer;

public interface IDataAccess
{
    /// <summary>
    /// Test method for adding to the "Posts" table.
    /// </summary>
    /// <param name="post">Posts object to add</param>
    public void Test_AddPosts(Posts post);

    /// <summary>
    /// Test method for adding to the "Slides" table.
    /// </summary>
    /// <param name="slide">Slides object to add</param>
    public void Test_AddSlides(Slides slide);

    /// <summary>
    /// Test method for adding to the "Groups" table.
    /// </summary>
    /// <param name="group">Groups object to add</param>
    public void Test_AddGroups(Groups group);

    /// <summary>
    /// Test method for adding to the "Changes" table.
    /// </summary>
    /// <param name="change">Changes object to add</param>
    public void Test_AddChanges(Changes changes);

    /// <summary>
    /// Test method for adding to the "Blacklist" table.
    /// </summary>
    /// <param name="blacklist">Blacklist object to add</param>
    public void Test_AddBlacklist(Blacklist blacklist);



}
