﻿namespace Meta_TV2_BusinessLayer;

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
    /// Gets a specific slide (including archived) associated with a specific slide Id by invoking datalayer and serializing result to JSON object.
    /// </summary>
    /// <param name="id">the slide Id to filter on</param>
    /// <returns>Slide JSON object if any slide were found, otherwise null</returns>
    public Task<string> GetSlideById(int id);

    /// <summary>
    /// Gets slides (non-archived) by pagination by invoking datalayer and serializing result to JSON object
    /// </summary>
    /// <param name="groupId">the group id to filter on</param>
    /// <param name="page">decides which set of Slides to return</param>
    /// <param name="size">the size of the page</param>
    /// <returns>Slide JSON object if any slide were found, otherwise null<</returns>
    public Task<string> GetSlidesByGroup(int groupId, int page, int size);

    /// <summary>
    /// Deserializes a Slide JSON object and adds the deserialized object to the database by invoking datalayer.
    /// </summary>
    /// <param name="slideObject">Slide JSON object</param>
    /// <returns>True if operation successfull otherwise false</returns>
    public Task<bool> AddSlide(string slideObject);

    /// <summary>
    /// Archives a specific slide in the database by updating the slide archived value and invoking datalayer.
    /// </summary>
    /// <param name="id">The id of the slide to archive</param>
    /// <returns>True if operation was successfull otherwise false.</returns>
    public Task<bool> ArchiveSlide(int id);

}
