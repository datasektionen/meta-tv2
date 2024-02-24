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

    public string GetGroupsTest(){
        try
        {
            List<Groups> result = DataAccess.GetGroupsTest();
            if (result.Count == 0 || result == null)
            {
                return null;
            }
            return JsonSerializer.Serialize(DataAccess.GetGroupsTest());
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
            return JsonSerializer.Serialize(data);
        else return null;
    }

    public async Task<bool> ArchiveGroup(int id){
        try
        {
            var group = await DataAccess.GetGroupById(id);
            group.Value.archive = true;
            group.Value.archiveDate = DateTime.Now;
            DataAccess.ArchiveGroup(group.Value);
            return true;
        }
        catch (Exception e)
        {
            // logg e?
            return false;
        }
    }

    public string GetGroups(int page, int size){
        try
        {
            List<Groups> result = DataAccess.GetGroups(page, size);
            if (result.Count == 0 || result == null)
            {
                return null;
            }
            return JsonSerializer.Serialize(DataAccess.GetGroups(page-1, size));
        }
        catch (Exception e)
        {
            // logg e?
            return null;
        }
    }
}
