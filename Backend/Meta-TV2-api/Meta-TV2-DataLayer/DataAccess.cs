using Microsoft.EntityFrameworkCore;

namespace Meta_TV2_DataLayer;

public class DataAccess : IDataAccess
{
    MetaTvContext db = new MetaTvContext();
    
    public async void AddGroups(Groups group){
        db.Add(group);
        await db.SaveChangesAsync();
        db.Dispose();
    }

    public async Task<Optional<List<Groups>>> GetGroups(){
        var query = from x in db.Groups where x.archive == false select x;
        var groups = await query.ToListAsync();
        if (groups.Count() == 0) {
            return Optional<List<Groups>>.Empty();
        }
        return Optional<List<Groups>>.Result(groups);
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
            Console.WriteLine($"Caught exception in GetGroupById({id}): {e.Message}");
            return Optional<Groups>.Empty();
        }
    }

    public async void UpdateGroup(Groups group){
        db.Update(group);
        await db.SaveChangesAsync();
        db.Dispose();
    }

    public async Task<Optional<List<Groups>>> GetGroups(int size, int page){
        var query = from x in db.Groups where x.archive == false select x;
        List<Groups> groups = await query.Skip((page-1) * size).Take(size).ToListAsync();
        if (groups.Count() == 0) {
            return Optional<List<Groups>>.Empty();
        }
        return Optional<List<Groups>>.Result(groups);
    }

    public async Task<Optional<List<Slides>>> GetSlides() {
        var query = from x in db.Slides where x.archive == false select x;
        var slides = await query.ToListAsync();
        if (slides.Count == 0) {
            return Optional<List<Slides>>.Empty();
        }
        return Optional<List<Slides>>.Result(slides);
    }

    public async Task<Optional<List<Slides>>> GetSlidesByGroup(int groupId) {
        var query = from x in db.Slides where x.archive == false & x.groupId == groupId select x;
        var slides = await query.ToListAsync();
        if(slides.Count == 0) {
            return Optional<List<Slides>>.Empty();
        }
        return Optional<List<Slides>>.Result(slides);
    }

    public async Task<Optional<Slides>> GetSlideById(int id) {
        var query = from x in db.Slides where x.slideId == id select x;
        var slide = await query.FirstOrDefaultAsync();
        if(slide == null) {
            return Optional<Slides>.Empty();
        }
        return Optional<Slides>.Result(slide);
    }

    public async Task<Optional<List<Slides>>> GetSlidesByGroup(int groupId, int page, int size) {
        var query = from x in db.Slides where x.archive == false & x.groupId == groupId select x;
        var groups = await query.Skip((page-1) * size).Take(size).ToListAsync();
        if (groups.Count == 0){
            return Optional<List<Slides>>.Empty();
        }
        return Optional<List<Slides>>.Result(groups);
    }

    public async void AddSlide(Slides obj) {
        db.Add(obj);
        await db.SaveChangesAsync();
        db.Dispose();
    }

    public async void UpdateSlide(Slides slide){
        db.Update(slide);
        await db.SaveChangesAsync();
        db.Dispose();
    }

    public async Task<Optional<List<Posts>>> GetPosts() {
        var query = from x in db.Posts join y in db.Slides on x.slideId equals y.slideId where y.archive == false select x;
        var result = await query.ToListAsync();
        if (result.Count == 0){
            return Optional<List<Posts>>.Empty();
        }
        return Optional<List<Posts>>.Result(result);
    }

    public async Task<Optional<List<Posts>>> GetPosts(int id) {
        var query = from x in db.Posts join y in db.Slides on x.slideId equals y.slideId where y.archive == false & x.slideId == id select x;
        var result = await query.ToListAsync();
        if (result.Count == 0){
            return Optional<List<Posts>>.Empty();
        }
        return Optional<List<Posts>>.Result(result);
    }

    public async void AddPostWithUrl(Posts post){
        db.Add(post);
        await db.SaveChangesAsync();
        db.Dispose();
    }

    public async Task<int> AddPostWithFile(Posts post) {
        db.Add(post);
        await db.SaveChangesAsync();
        db.Dispose();
        return post.postId; //Can this always be garantied?
    }

    public async Task<Optional<Posts>> GetPostByPostId(int id) {
        var query = from x in db.Posts where x.postId == id select x;
        var post = await query.FirstAsync();
        db.Dispose();
        if(post == null)
            return Optional<Posts>.Empty();
        return Optional<Posts>.Result(post);
    }
}
