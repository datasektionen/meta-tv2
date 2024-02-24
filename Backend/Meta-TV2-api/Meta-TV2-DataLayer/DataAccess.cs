using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Meta_TV2_DataLayer;

// Värt att kolla in "transactions" för timeouts
public class DataAccess : IDataAccess
{
    MetaTvContext db = new MetaTvContext();
    
    public void Test_AddPosts(Posts post){
        db.Add(post);
        db.SaveChanges();
        db.Dispose();
    }

    public void Test_AddSlides(Slides slide){
        db.Add(slide);
        db.SaveChanges();
        db.Dispose();
    }

    public void Test_AddGroups(Groups group){
        db.Add(group);
        db.SaveChanges();
        db.Dispose();
    }

    public void Test_AddChanges(Changes change){
        db.Add(change);
        db.SaveChanges();
        db.Dispose();
    }

    public void Test_AddBlacklist(Blacklist blacklist){
        db.Add(blacklist);
        db.SaveChanges();
        db.Dispose();
    }

    // public string getFirstAlphabetical(){
    //     var query = from x in db.Blacklist select x;
    //     Blacklist a = query.First();
    //     return a.alias;
    // }

    public List<Groups> GetGroupsTest(){
        var query = from x in db.Groups where x.archive == false select x;
        return query.ToList();
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

    public List<Groups> GetGroups(int page, int size){
        var query = (from x in db.Groups where x.archive == false select x);
        List<Groups> groups = query.Skip((page - 1) * size).Take(size).ToList();
        return groups;
    }
}
