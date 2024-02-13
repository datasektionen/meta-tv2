using Microsoft.VisualBasic;

namespace Meta_TV2_DataLayer;

public class DataAccess : IDataAccess
{
    MetaTvContext db = new MetaTvContext();
    
    public void TestData(string Name){
        db.Add(new Blacklist {alias = Name});
        db.SaveChanges();
    }

    public string getFirstAlphabetical(){
        var query = from x in db.Blacklist select x;
        Blacklist a = query.First();
        return a.alias;
    }
}
