using Microsoft.EntityFrameworkCore;

namespace Meta_TV2_DataLayer;

// Värt att kolla in "transactions" för timeouts
public class DataAccess : IDataAccess
{
    MetaTvContext db = new MetaTvContext();
    
    public async void AddGroups(Groups group){
        db.Add(group);
        await db.SaveChangesAsync();
        db.Dispose();
    }

    public void Test_AddBlacklist(Blacklist blacklist){
        db.Add(blacklist);
        db.SaveChanges();
        db.Dispose();
    }

    public async Task<List<Groups>> GetGroups(){
        var query = from x in db.Groups where x.archive == false select x;
        return await query.ToListAsync();
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

    public async void ArchiveGroup(Groups group){
        db.Update(group);
        await db.SaveChangesAsync();
        db.Dispose();
    }

    public async Task<Optional<List<Groups>>> GetGroups(int page, int size){
        var query = (from x in db.Groups where x.archive == false select x);
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
        List<Slides> groups = await query.Skip((page-1) * size).Take(size).ToListAsync();
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
}
