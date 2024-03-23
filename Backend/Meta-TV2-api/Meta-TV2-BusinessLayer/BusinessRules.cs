﻿namespace Meta_TV2_BusinessLayer;

using System.Text.Json;
using Meta_TV2_DataLayer;

public class BusinessRules : IBusinessRules
{
    IDataAccess DataAccess = new DataAccess();

    public async Task<bool> AddGroup(string groupObject){
        try
        {
            // Convert string to a stream
            using var stream = new MemoryStream();
            using (var writer = new StreamWriter(stream, leaveOpen: true))
            {
                await writer.WriteAsync(groupObject);
                await writer.FlushAsync();
            }
            stream.Position = 0; // Reset the stream position to the beginning

            // Deserialize the JSON content from the stream asynchronously
            var obj = await JsonSerializer.DeserializeAsync<Groups>(stream);
            
            DataAccess.AddGroups(obj);
            return true;
        }
        catch (Exception e)
        {
            // logg e?
            return false;
        }
    }

    public async Task<string> GetGroups(){
        try
        {
            var data = await DataAccess.GetGroups();
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

    public async Task<string> GetGroupById(int id){
        var data = await DataAccess.GetGroupById(id);
        if (data.HasValue)
            return JsonSerializer.Serialize(data.Value);
        else return null;
    }

    public async Task<bool> ArchiveGroup(int id){
        try
        {
            // Get the group by Id
            var group = await DataAccess.GetGroupById(id);
            
            // Modify the group attributes
            group.Value.archive = true;
            group.Value.archiveDate = DateTime.Now;

            // Update database
            DataAccess.UpdateGroup(group.Value);
            return true;
        }
        catch (Exception e)
        {
            // logg e?
            return false;
        }
    }

    public async Task<string> GetGroups(int page, int size){
        try
        {
            var data = await DataAccess.GetGroups(page, size);
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
            var result = await DataAccess.GetSlides();
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
            var result = await DataAccess.GetSlidesByGroup(groupId);
            if(!result.HasValue) 
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch (Exception e) {
            return null;
        }
    }

    public async Task<string> GetSlideById(int id) {
        try{
            var result = await DataAccess.GetSlideById(id);
            if(!result.HasValue)
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch(Exception e) {
            return null;
        }
    }

    public async Task<string> GetSlidesByGroup(int groupId, int page, int size) {
        try {
            var result = await DataAccess.GetSlidesByGroup(groupId, page, size);
            if(!result.HasValue) 
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch(Exception e){
            return null;
        }
    }

    public async Task<bool> AddSlide(string slideObject){
        try {
            var slide = JsonSerializer.Deserialize<Slides>(slideObject);
            DataAccess.AddSlide(slide);
            return true;
        } catch(Exception e) {
            return false;
        }
    }

    public async Task<bool> ArchiveSlide(int id){
        try {
            var slide = await DataAccess.GetSlideById(id);
            if (!slide.HasValue) 
                return false;
            slide.Value.archive = true;
            slide.Value.archiveDate = DateTime.Now;
            DataAccess.UpdateSlide(slide.Value);
            return true;
        } catch(Exception e) {
            return false;
        }
    }

    public async Task<string> GetPosts() {
        try {
            var posts = await DataAccess.GetPosts();
            if (!posts.HasValue)
                return null;
            return JsonSerializer.Serialize(posts.Value);
        } catch (Exception e) {
            return null;
        }
    }

    public async Task<string> GetPosts(int id) {
        try {
            var posts = await DataAccess.GetPosts(id);
            if (!posts.HasValue)
                return null;
            return JsonSerializer.Serialize(posts.Value);
        } catch (Exception e) {
            return null;
        }
    }

    public async Task<bool> AddPostWithUrl(string post) {
        try {
            var deserializedPost = JsonSerializer.Deserialize<Posts>(post);
            if (deserializedPost.filePath == "" || deserializedPost.pathType != "Url")
                return false;
            DataAccess.AddPostWithUrl(deserializedPost);
            return true;
        } catch (Exception e) {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<string> AddPostWithFile(string post, string fileType) {
        try {
            var deserializedPost = JsonSerializer.Deserialize<Posts>(post);
            deserializedPost.filePath = "."+fileType;
            int id = await DataAccess.AddPostWithFile(deserializedPost);
            return Path.Combine(deserializedPost.pathType, id.ToString());
            
        } catch(Exception e){
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<(string, string)> GetPostFileType(int id) {
        try {
            var post = await DataAccess.GetPostByPostId(id);
            if (!post.HasValue)
                return (null, null);
            if(post.Value.pathType == "Url")
                return ("Url", post.Value.filePath);
            return (post.Value.pathType, post.Value.filePath);
        } catch (Exception e){
            return (null, null);
        }
    }

}