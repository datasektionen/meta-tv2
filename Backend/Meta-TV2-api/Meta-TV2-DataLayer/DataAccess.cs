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
}
