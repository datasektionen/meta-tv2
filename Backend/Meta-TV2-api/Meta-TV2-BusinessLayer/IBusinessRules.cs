﻿using Meta_TV2_DataLayer;

namespace Meta_TV2_BusinessLayer;

public interface IBusinessRules
{
    /// <summary>
    /// Invokes the datalayer method to fetch if an alias is blacklisted
    /// </summary>
    /// <param name="alias">The alias to look for</param>
    /// <returns>Optional object with the Blacklist object as value, otherwise empty Optional object if no record of alias found</returns>
    public Task<Optional<Blacklist>> GetBlacklistByAlias(string alias);

    /// <summary>
    /// Deserializes a Blacklist JSON object and adds the deserialized object to the database by invoking datalayer.
    /// </summary>
    /// <param name="alias">Blacklist JSON object</param>
    /// <returns>True if operation successfull otherwise false</returns>
    public bool BanUser(string alias);

    /// <summary>
    /// Gets blacklisted users from the database by invoking datalayer and serializing result to JSON object.
    /// </summary>
    /// <returns>Blacklisted JSON object if any groups were found, otherwise null</returns>
    public Task<string> GetBlacklistedUsers();

    /// <summary>
    /// Unbans a user with the given alias.
    /// </summary>
    /// <returns>Return true if successful and false otherwise</returns>
    /// <param name="alias"> Alias of the user to unban </param>
    public  Task<bool> UnbanUser(string alias);

    /// <summary>
    /// Adds the Group object to database by invoking datalayer
    /// </summary>
    /// <param name="groupObject">Group JSON object</param>
    /// <returns>True if successfull otherwise false</returns>
    public bool AddGroup(Groups groupObject);

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
    /// Gets slides (non-archived) by pagination by invoking datalayer and serializing result to JSON object
    /// </summary>
    /// <param name="groupId">the group id to filter on</param>
    /// <param name="page">decides which set of Slides to return</param>
    /// <param name="size">the size of the page</param>
    /// <returns>Slide JSON object if any slide were found, otherwise null<</returns>
    public Task<string> GetSlidesByGroup(int groupId, int page, int size);

    /// <summary>
    /// Gets a specific slide (including archived) associated with a specific slide Id by invoking datalayer and serializing result to JSON object.
    /// </summary>
    /// <param name="id">the slide Id to filter on</param>
    /// <returns>Slide JSON object if any slide were found, otherwise null</returns>
    public Task<string> GetSlideById(int id);

    /// <summary>
    /// Adds the Slides object to the database by invoking datalayer.
    /// </summary>
    /// <param name="slideObject">Slide JSON object</param>
    /// <returns>True if operation successfull otherwise false</returns>
    public bool AddSlide(Slides slideObject);

    /// <summary>
    /// Archives a specific slide in the database by updating the slide archived value and invoking datalayer.
    /// </summary>
    /// <param name="id">The id of the slide to archive</param>
    /// <returns>True if operation was successfull otherwise false.</returns>
    public Task<bool> ArchiveSlide(int id);

    /// <summary>
    /// Gets all non archived posts from the database and serializes the result to JSON object.
    /// </summary>
    /// <returns>JSON object if posts found, otherwise null</returns>
    public Task<string> GetPosts();

    /// <summary>
    /// Gets all posts associated with a specific slide id that is not archived from the database and serializes the result to JSON object.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>JSON object of posts, or null if none found</returns>
    public Task<string> GetPosts(int id);

    /// <summary>
    /// Gets the file type of a post by invoking datalayer.
    /// Can only be one of these: Image, Video, Html or Url.
    /// Ignores if the post is archived or not.
    /// </summary>
    /// <param name="id">The post id to sort on</param>
    /// <returns>Tuple of strings, first being file type, second being filepath, if non found null on both.</returns>
    public Task<(string, string)> GetPostFileType(int id);

    /// <summary>
    /// Creates a new post with a assosciated file by invoking datalayer
    /// The posts pathType attribute should correspond to the associated file type
    /// pathType can only be: Image, Video, Html or Url
    /// </summary>
    /// <param name="post">The post</param>
    /// <param name="file">The file associated with post</param>
    /// <returns>True if operation sucessfull, otherwise false</returns>
    public Task<bool> AddPost(string post, ICustomFormFile file);
}
