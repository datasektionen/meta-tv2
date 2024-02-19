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

    public List<Groups> GetGroups(){
        var query = (from x in db.Groups where x.archive == false select x);
        List<Groups> groups = query.ToList();
        return groups;

    }

    public Groups GetGroupById(int id){
        var query = (from x in db.Groups where x.groupId == id select x);
        Groups group = query.First();
        return group;
    }

    public void ArchiveGroup(Groups group){
        db.Update(group);
        db.SaveChanges();
        db.Dispose();
    }
}
