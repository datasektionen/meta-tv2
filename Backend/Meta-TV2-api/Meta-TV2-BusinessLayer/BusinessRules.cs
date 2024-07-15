namespace Meta_TV2_BusinessLayer;

using System.Text.Json;
using Meta_TV2_DataLayer;

public class BusinessRules : IBusinessRules
{
    IDataAccess dataAccess = new DataAccess();

    public async Task<Optional<Blacklist>> GetBlacklistByAlias(string alias){
        try
        {
            return await dataAccess.GetBlacklistByAlias(alias);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public bool BanUser(string alias){
        try {
            var blacklist = JsonSerializer.Deserialize<Blacklist>(alias);
            dataAccess.AddBlacklist(blacklist);
            return true;
        } 
        catch(Exception e) {
            Console.WriteLine(e);
            return false;
        }
    }
    public async Task<string> GetBlacklistedUsers() {
        try
        {
            var result = await dataAccess.GetBlacklistedUsers();
            if(!result.HasValue) 
                return "";
            return JsonSerializer.Serialize(result.Value);
        }
        catch (Exception e)
        {  
            //logg e?
            return null;
        }
    }

    public async Task<bool> UnbanUser(string alias) {
        try {
            var entry = await dataAccess.GetBlacklistByAlias(alias);
            if(entry.HasValue) {
                dataAccess.RemoveFromBlacklist(entry.Value);
                return true;
            }
            return false;
        }
        catch (Exception e) {
            //logg e?
            return false;
        }
    }

    public bool AddGroup(Groups groupObject){
        try
        {
            dataAccess.AddGroups(groupObject);
            return true;
        }
        catch (Exception e)
        {
            // logg e?
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<string> GetGroups(){
        try
        {
            var data = await dataAccess.GetGroups();
            if (data.HasValue)
                return JsonSerializer.Serialize(data.Value);
            else return null;
        }
        catch (Exception e)
        {
            // logg e?
            return null;
        }
    }

    // TODO: Add try-catch
    public async Task<string> GetGroupById(int id){
        var data = await dataAccess.GetGroupById(id);
        if (data.HasValue)
            return JsonSerializer.Serialize(data.Value);
        else return null;
    }

    public async Task<bool> ArchiveGroup(int id){
        try
        {
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
        catch (Exception e)
        {
            // logg e?
            return false;
        }
    }

    // TODO: Swap page and size to match datalayer method signature. Swap this signature as well and change in accesslayer.
    public async Task<string> GetGroups(int page, int size){
        try
        {
            var data = await dataAccess.GetGroups(page, size);
            if(data.HasValue)
                return JsonSerializer.Serialize(data.Value);
            else return null;
        }
        catch (Exception e)
        {
            // logg e?
            return null;
        }
    }

    public async Task<string> GetSlides() {
        try
        {
            var result = await dataAccess.GetSlides();
            if(!result.HasValue) 
                return null;
            return JsonSerializer.Serialize(result.Value);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<string> GetSlidesByGroup(int groupId) {
        try {
            var result = await dataAccess.GetSlidesByGroup(groupId);
            if(!result.HasValue) 
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch (Exception e) {
            return null;
        }
    }

    public async Task<string> GetSlideById(int id) {
        try{
            var result = await dataAccess.GetSlideById(id);
            if(!result.HasValue)
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch(Exception e) {
            return null;
        }
    }

    public async Task<string> GetSlidesByGroup(int groupId, int page, int size) {
        try {
            var result = await dataAccess.GetSlidesByGroup(groupId, page, size);
            if(!result.HasValue) 
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch(Exception e){
            return null;
        }
    }

    public bool AddSlide(Slides slideObject){
        try {
            dataAccess.AddSlide(slideObject);
            return true;
        } catch(Exception e) {
            return false;
        }
    }

    public async Task<bool> ArchiveSlide(int id){
        try {
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
        } catch(Exception e) {
            return false;
        }
    }

    public async Task<string> GetPosts() {
        try {
            var posts = await dataAccess.GetPosts();
            if (!posts.HasValue)
                return null;
            return JsonSerializer.Serialize(posts.Value);
        } catch (Exception e) {
            return null;
        }
    }

    public async Task<string> GetPosts(int id) {
        try {
            var posts = await dataAccess.GetPosts(id);
            if (!posts.HasValue)
                return null;
            return JsonSerializer.Serialize(posts.Value);
        } catch (Exception e) {
            return null;
        }
    }

    public async Task<(string, string)> GetPostFileInfo(int id) {
        try {
            var post = await dataAccess.GetPostByPostId(id);
            if (!post.HasValue)
                return (null, null);
            if(post.Value.pathType == "Url")
                return ("Url", post.Value.filePath);
            return (post.Value.pathType, post.Value.filePath);
        } catch (Exception e){
            return (null, null);
        }
    }

    public async Task<bool> AddPost(string post, ICustomFormFile file)
    {
        try {
            var deserializedPost = JsonSerializer.Deserialize<Posts>(post);

            if (file.IsEmpty)
                return false;   // No file was passed

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
            return false;
        }
    }
}
