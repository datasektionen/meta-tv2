using Microsoft.EntityFrameworkCore;
using Npgsql;

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

    // public string getFirstAlphabetical(){
    //     var query = from x in db.Blacklist select x;
    //     Blacklist a = query.First();
    //     return a.alias;
    // }

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
}
