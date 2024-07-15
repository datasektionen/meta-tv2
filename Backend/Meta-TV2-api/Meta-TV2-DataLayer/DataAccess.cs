using Meta_TV2_Utils;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Meta_TV2_DataLayer;

public class DataAccess : IDataAccess
{
    private ILogger _logger = new Logger();
    MetaTvContext db = new MetaTvContext();

    public async void AddGroups(Groups group){
        db.Add(group);
        await db.SaveChangesAsync();
        _logger.Log(LogLevels.INFORMATION, $"Group added. Title: {group.title}, Created by: {group.createdBy}", "DataAccess.AddGroups", DateTime.Now);
        db.Dispose();
    }

    public async Task<Optional<List<Groups>>> GetGroups(){
        try
        {
            var query = from x in db.Groups where x.archive == false select x;
            var groups = await query.ToListAsync();
            if (groups.Count() != 0)
                return Optional<List<Groups>>.Result(groups);
            else return Optional<List<Groups>>.Empty();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, e.Message, "DataAccess.GetGroups()", DateTime.Now);
            return Optional<List<Groups>>.Empty();
        }
    }

    public async Task<Optional<List<Groups>>> GetGroups(int size, int page){
        try
        {
            var query = from x in db.Groups where x.archive == false select x;
            List<Groups> groups = await query.Skip((page-1) * size).Take(size).ToListAsync();
            if (groups.Count() != 0)
                return Optional<List<Groups>>.Result(groups);
            else return Optional<List<Groups>>.Empty();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, e.Message, "DataAccess.GetGroups(size, page)", DateTime.Now);
            return Optional<List<Groups>>.Empty();
        }
    }
    
    public async Task<Optional<Groups>> GetGroupById(int id){
        try
        {
            var query = from x in db.Groups where x.groupId == id select x;
            var group = await query.FirstOrDefaultAsync();
            if (group != null)
                return Optional<Groups>.Result(group);
            else return Optional<Groups>.Empty();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, $"groupId: {id}. {e.Message}", "DataAccess.GetGroupById", DateTime.Now);
            return Optional<Groups>.Empty();
        }
    }

    public async void UpdateGroup(Groups group){
        db.Update(group);
        await db.SaveChangesAsync();
        _logger.Log(LogLevels.INFORMATION, $"Group updated. Id: {group.groupId}", "DataAccess.UpdateGroup", DateTime.Now);
        db.Dispose();
    }

    public async Task<Optional<List<Slides>>> GetSlides() {
        try
        {
            var query = from x in db.Slides where x.archive == false select x;
            var slides = await query.ToListAsync();
            if (slides.Count != 0)
                return Optional<List<Slides>>.Result(slides);
            else return Optional<List<Slides>>.Empty();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, e.Message, "DataAccess.GetSlides", DateTime.Now);
            return Optional<List<Slides>>.Empty();
        }
    }

    public async Task<Optional<List<Slides>>> GetSlidesByGroup(int groupId) {
        try
        {
            var query = from x in db.Slides where x.archive == false & x.groupId == groupId select x;
            var slides = await query.ToListAsync();
            if(slides.Count != 0)
                return Optional<List<Slides>>.Result(slides);
            else return Optional<List<Slides>>.Empty();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, $"groupId: {groupId}. {e.Message}", "DataAccess.GetSlidesByGroup(groupId)", DateTime.Now);
            return Optional<List<Slides>>.Empty();
        }
    }

    public async Task<Optional<List<Slides>>> GetSlidesByGroup(int groupId, int page, int size) {
        try
        {
            var query = from x in db.Slides where x.archive == false & x.groupId == groupId select x;
            List<Slides> groups = await query.Skip((page-1) * size).Take(size).ToListAsync();
            if (groups.Count != 0)
                return Optional<List<Slides>>.Result(groups);
            else return Optional<List<Slides>>.Empty();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, $"groupId: {groupId}. {e.Message}", "DataAccess.GetSlidesByGroup(groupId, page, size)", DateTime.Now);
            return Optional<List<Slides>>.Empty();
        }
    }

    public async Task<Optional<Slides>> GetSlideById(int id) {
        try
        {
            var query = from x in db.Slides where x.slideId == id select x;
            var slide = await query.FirstOrDefaultAsync();
            if(slide != null)
                return Optional<Slides>.Result(slide);
            else return Optional<Slides>.Empty();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, $"slideId: {id}. {e.Message}", "DataAccess.GetSlideById", DateTime.Now);
            return Optional<Slides>.Empty();
        }
    }

    public async void AddSlide(Slides slide) {
        db.Add(slide);
        await db.SaveChangesAsync();
        _logger.Log(LogLevels.INFORMATION, $"Slide added. groupId: {slide.groupId}", "DataAccess.AddSlide", DateTime.Now);
        db.Dispose();
    }

    public async void UpdateSlide(Slides slide){
        db.Update(slide);
        await db.SaveChangesAsync();
        _logger.Log(LogLevels.INFORMATION, $"Slide updated. groupId: {slide.groupId}", "DataAccess.UpdateSlide", DateTime.Now);
        db.Dispose();
    }

    public async Task<Optional<List<Posts>>> GetPosts() {
        try
        {
            var query = from x in db.Posts join y in db.Slides on x.slideId equals y.slideId where y.archive == false select x;
            var result = await query.ToListAsync();
            if (result.Count == 0)
                return Optional<List<Posts>>.Empty();
            return Optional<List<Posts>>.Result(result);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, e.Message, "DataAccess.GetPosts", DateTime.Now);
            return Optional<List<Posts>>.Empty();
        }

    }

    public async Task<Optional<List<Posts>>> GetPosts(int id) {
        try
        {
            var query = from x in db.Posts join y in db.Slides on x.slideId equals y.slideId where y.archive == false & x.slideId == id select x;
            var result = await query.ToListAsync();
            if (result.Count == 0)
                return Optional<List<Posts>>.Empty();
            return Optional<List<Posts>>.Result(result);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, $"slideId: {id}. {e.Message}", "DataAccess.GetPosts", DateTime.Now);
            return Optional<List<Posts>>.Empty();
        }
    }

    public async void AddPostWithUrl(Posts post){
        db.Add(post);
        await db.SaveChangesAsync();
        _logger.Log(LogLevels.INFORMATION, $"Post added (URL). File path: {post.filePath}", "DataAccess.AddPostWithUrl", DateTime.Now);
        db.Dispose();
    }

    public async Task<int> AddPostWithFile(Posts post) {
        db.Add(post);
        await db.SaveChangesAsync();
        _logger.Log(LogLevels.INFORMATION, $"Post added (File). File path: {post.filePath}", "DataAccess.AddPostWithFile", DateTime.Now);
        db.Dispose();
        return post.postId;
    }

    public async Task<Optional<Posts>> GetPostByPostId(int id) {
        try
        {
            var query = from x in db.Posts where x.postId == id select x;
            var post = await query.FirstAsync();
            db.Dispose();
            if(post == null)
                return Optional<Posts>.Empty();
            return Optional<Posts>.Result(post);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, $"PostId: {id}. {e.Message}", "DataAccess.GetPostByPostId", DateTime.Now);
            return Optional<Posts>.Empty();
        }
    }

    public async void AddBlacklist(Blacklist obj) {
        db.Add(obj);
        await db.SaveChangesAsync();
        _logger.Log(LogLevels.INFORMATION, $"Blacklisted user added. Alias: {obj.alias}", "DataAccess.AddGroups", DateTime.Now);
        db.Dispose();
    }
    
    public async Task<Optional<List<Blacklist>>> GetBlacklistedUsers() {
        try
        {
            var query = from x in db.Blacklist select x;
            var blacklists = await query.ToListAsync();
            if (blacklists.Count != 0)
                return Optional<List<Blacklist>>.Result(blacklists);
            return Optional<List<Blacklist>>.Empty();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, $"{e.Message}", "DataAccess.GetBlacklistedUsers", DateTime.Now);
            throw;
        }
    }

    public async Task<Optional<Blacklist>> GetBlacklistByAlias(string alias) {
        try
        {
            var query = from x in db.Blacklist where x.alias == alias select x;
            var foundAlias = await query.FirstOrDefaultAsync();
            if (foundAlias != null)
                return Optional<Blacklist>.Result(foundAlias);
            else return Optional<Blacklist>.Empty();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevels.ERROR, $"Alias: {alias}. {e.Message}", "DataAccess.GetBlacklistByAlias", DateTime.Now);
            return Optional<Blacklist>.Empty();
        }
    }

    public async void RemoveFromBlacklist(Blacklist obj){
        db.Blacklist.Remove(obj);
        await db.SaveChangesAsync();
        _logger.Log(LogLevels.INFORMATION, $"Blacklist removed. Alias: {obj.alias}", "DataAccess.RemoveFromBlacklist", DateTime.Now);
        db.Dispose();
    }
}
