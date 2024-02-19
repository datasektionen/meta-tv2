namespace Meta_TV2_BusinessLayer;

using System.Text.Json;
using Meta_TV2_DataLayer;

public class BusinessRules : IBusinessRules
{
    IDataAccess DataAccess = new DataAccess();

    public bool AddGroup(string groupObject){
        try
        {
            var obj = JsonSerializer.Deserialize<Groups>(groupObject);
            DataAccess.Test_AddGroups(obj);
            return true;
        }
        catch (Exception e)
        {
            // logg e?
            return false;
        }
    }

    public string GetGroups(){
        try
        {
            List<Groups> result = DataAccess.GetGroups();
            if (result.Count == 0 || result == null)
            {
                return null;
            }
            return JsonSerializer.Serialize(DataAccess.GetGroups());
        }
        catch (Exception e)
        {
            // logg e?
            return null;
        }
    }

    public string GetGroupById(int id){
        try
        {
            return JsonSerializer.Serialize(DataAccess.GetGroupById(id));
        }
        catch (Exception e)
        {
            // logg e?
            return null;
        }
    }

    public bool ArchiveGroup(int id){
        try
        {
            var group = DataAccess.GetGroupById(id);
            group.archive = true;
            group.archiveDate = DateTime.Now;
            DataAccess.ArchiveGroup(group);
            return true;
        }
        catch (Exception e)
        {
            // logg e?
            return false;
        }
    }
}
