using System.Text.Json;
using Meta_TV2_DataLayer;
using Meta_TV2_Utils;

namespace Meta_TV2_BusinessLayer;

public class BusinessRules : IBusinessRules
{
    private Logger _logger = new Logger();
    IDataAccess dataAccess = new DataAccess();

    public bool AddGroup(Groups groupObject){
        if (groupObject == null) {
            _logger.Log(LogLevels.WARNING, "Null object was passed", "BusinessRules.AddGroup", DateTime.Now);
            return false;
        }
        dataAccess.AddGroups(groupObject);
        return true;
    }

    public async Task<string> GetGroups(){
        var data = await dataAccess.GetGroups();
        if (data.HasValue) {
            try
            {
                return JsonSerializer.Serialize(data.Value);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevels.WARNING, $"Serialization threw an exception: {e.Message}", "BusinessRules.GetGroups", DateTime.Now);
                return null;
            }
        }
        return null;
    }

    public async Task<string> GetGroupById(int id){
        if (id == 0) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching group with GroupId 0", "BusinessRules.GetGroupById", DateTime.Now);
            return null;
        }
        var data = await dataAccess.GetGroupById(id);
        if (data.HasValue) {
            try
            {
                return JsonSerializer.Serialize(data.Value);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevels.WARNING, $"Serialization threw an exception: {e.Message}", "BusinessRules.GetGroupById", DateTime.Now);
                return null;
            }
        }
        else return null;
    }

    public async Task<bool> ArchiveGroup(int id){
        if (id == 0) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching group with GroupId 0", "BusinessRules.ArchiveGroup", DateTime.Now);
            return false;
        }
        var group = await dataAccess.GetGroupById(id);
        if (!group.HasValue)
            return false;

        if (!group.Value.archive){      // Makes sure to not archive an archived slide
            // Modify the group attributes
            group.Value.archive = true;
            group.Value.archiveDate = DateTime.Now;

            // Update database
            dataAccess.UpdateGroup(group.Value);
        }
        return true;
    }

    // TODO: Swap page and size to match datalayer method signature. Swap this signature as well and change in accesslayer.
    public async Task<string> GetGroups(int page, int size){        
        var data = await dataAccess.GetGroups(page, size);
        if (data.HasValue){
            try
            {
                return JsonSerializer.Serialize(data.Value);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevels.WARNING, $"Serialization threw an exception: {e.Message}", "BusinessRules.GetGroups(page, size)", DateTime.Now);
                return null;
            }
        }
        else return null;
    }

    public async Task<string> GetSlides() {
        var result = await dataAccess.GetSlides();
        if (result.HasValue) {
            try
            {
                return JsonSerializer.Serialize(result.Value);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevels.WARNING, $"Serialization threw an exception: {e.Message}", "BusinessRules.GetSlides", DateTime.Now);
                return null;
            }
        }
        else return null;
        
    }

    public async Task<string> GetSlidesByGroup(int groupId) {
        if (groupId == 0) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching slides with GroupId 0", "BusinessRules.GetSlidesByGroup", DateTime.Now);
            return null;
        }
        var result = await dataAccess.GetSlidesByGroup(groupId);
        if (result.HasValue) {
            try
            {
                return JsonSerializer.Serialize(result.Value);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevels.WARNING, $"Serialization threw an exception: {e.Message}", "BusinessRules.GetSlidesByGroup", DateTime.Now);
                return null;
            }
        }
        else return null;
    }

    public async Task<string> GetSlideById(int id) {
        if (id == 0) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching slides with SlideId 0", "BusinessRules.GetSlideById", DateTime.Now);
            return null;
        }
        var result = await dataAccess.GetSlideById(id);
        if (result.HasValue) {
            try
            {
                return JsonSerializer.Serialize(result.Value);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevels.WARNING, $"Serialization threw an exception: {e.Message}", "BusinessRules.GetSlideById", DateTime.Now);
                return null;
            }
        }
        else return null;
    }

    public async Task<string> GetSlidesByGroup(int groupId, int page, int size) {
        if (groupId == 0) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching slides with GroupId 0", "BusinessRules.GetSlidesByGroup(page, size)", DateTime.Now);
            return null;
        }
        var result = await dataAccess.GetSlidesByGroup(groupId, page, size);
        if (result.HasValue) {
            try
            {
                return JsonSerializer.Serialize(result.Value);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevels.WARNING, $"Serialization threw an exception: {e.Message}", "BusinessRules.GetSlidesByGroup(page, size)", DateTime.Now);
                return null;
            }
        }
        else return null;
    }

    public bool AddSlide(Slides slideObject){
        if (slideObject == null) {
            _logger.Log(LogLevels.WARNING, "Null object was passed", "BusinessRules.AddSlide", DateTime.Now);
            return false;
        }
        dataAccess.AddSlide(slideObject);
        return true;
    }

    public async Task<bool> ArchiveSlide(int id){
        if (id == 0) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching slide with SlideId 0", "BusinessRules.ArchiveSlide", DateTime.Now);
            return false;
        }
        var slide = await dataAccess.GetSlideById(id);
        if (!slide.HasValue) 
            return false;
        
        if (!slide.Value.archive){      // Makes sure to not archive an archived slide
            // Modify the group attributes
            slide.Value.archive = true;
            slide.Value.archiveDate = DateTime.Now;

            // Update database
            dataAccess.UpdateSlide(slide.Value);
        }
        return true;
    }

    public async Task<string> GetPosts() {
        var posts = await dataAccess.GetPosts();
        if (posts.HasValue) {
            try
            {
                return JsonSerializer.Serialize(posts.Value);  
            }
            catch (Exception e)
            {
                _logger.Log(LogLevels.WARNING, $"Serialization threw an exception: {e.Message}", "BusinessRules.GetPosts", DateTime.Now);
                return null;
            }
        }
        else return null;
    }

    public async Task<string> GetPostsBySlide(int slideId) {
        if (slideId == 0) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching post with SlideId 0", "BusinessRules.GetPostsBySlide", DateTime.Now);
            return null;
        }
        var posts = await dataAccess.GetPostsBySlide(slideId);
        if (posts.HasValue) {
            try
            {
                return JsonSerializer.Serialize(posts.Value);  
            }
            catch (Exception e)
            {
                _logger.Log(LogLevels.WARNING, $"Serialization threw an exception: {e.Message}", "BusinessRules.GetPostsBySlide", DateTime.Now);
                return null;
            }
        }
        else return null;
    }

    public async Task<(string, string)> GetPostFileInfo(int id) {
        if (id == 0) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching post with PostId 0", "BusinessRules.GetPostsBySlide", DateTime.Now);
            return (null, null);
        }
        var post = await dataAccess.GetPostByPostId(id);
        if (post.HasValue)
            return (post.Value.pathType, post.Value.filePath);
        else return (null, null);
    }

    public async Task<bool> AddPost(string post, ICustomFormFile file)
    {
        if (post == null || file.IsEmpty) {
            _logger.Log(LogLevels.WARNING, $"File and/or JSON was null when adding post", "BusinessRules.AddPost", DateTime.Now);
            return false;
        }
        try {
            var deserializedPost = JsonSerializer.Deserialize<Posts>(post);

            if (deserializedPost.pathType != "Url" && deserializedPost.pathType != "Video" && deserializedPost.pathType != "Image" && deserializedPost.pathType != "Html")
                return false;

            if (deserializedPost.pathType == "Url" & deserializedPost.filePath != "")
            { // Handle URL case
                dataAccess.AddPostWithUrl(deserializedPost);
                return true;
            }

            deserializedPost.filePath = "." + file.ContentType.Split("/")[1];
            int id = await dataAccess.AddPostWithFile(deserializedPost);

            if (id == -1)
                return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", deserializedPost.pathType, id.ToString() + "." + file.ContentType.Split("/")[1]);
            
            // Get the directory from the file path
            var directory = Path.GetDirectoryName(path);

            // Ensure that the directory exists
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Write the file to the directory
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return true;
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.WARNING, $"Something went wrong when adding a post: {e.Message}", "BusinessRules.AddPost", DateTime.Now);
            return false;
        }
    }

    public async Task<Optional<Blacklist>> GetBlacklistByAlias(string alias){
        if (string.IsNullOrEmpty(alias)) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching blacklist with empty or null alias", "BusinessRules.GetBlacklistByAlias", DateTime.Now);
            return null;
        }
        return await dataAccess.GetBlacklistByAlias(alias);
    }

    public bool BanUser(string alias){
        if (string.IsNullOrEmpty(alias)) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching blacklist with empty or null alias", "BusinessRules.GetBlacklistByAlias", DateTime.Now);
            return false;
        }
        try
        {
            var blacklist = JsonSerializer.Deserialize<Blacklist>(alias);
            dataAccess.AddBlacklist(blacklist);
            return true;
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.WARNING, $"Deserialization threw an exception: {e.Message}", "BusinessRules.BanUser", DateTime.Now);
            return false;
        }
    }
    
    public async Task<string> GetBlacklistedUsers() {
        var result = await dataAccess.GetBlacklistedUsers();
        if(result.HasValue) {
            try
            {
                return JsonSerializer.Serialize(result.Value);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevels.WARNING, $"Serialization threw an exception: {e.Message}", "BusinessRules.GetBlacklistedUsers", DateTime.Now);
                return null;
            }
        }
        else return null;
    }

    public async Task<bool> UnbanUser(string alias) {
        if (string.IsNullOrEmpty(alias)) {
            _logger.Log(LogLevels.WARNING, $"Tried fetching blacklist with empty or null alias", "BusinessRules.UnbanUser", DateTime.Now);
            return false;
        }
        var entry = await dataAccess.GetBlacklistByAlias(alias);
        if(entry.HasValue) {
            dataAccess.RemoveFromBlacklist(entry.Value);
            return true;
        }
        return false;
    }
}
