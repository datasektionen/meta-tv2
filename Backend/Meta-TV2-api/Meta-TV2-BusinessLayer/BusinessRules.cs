namespace Meta_TV2_BusinessLayer;

using System.Text.Json;
using Meta_TV2_DataLayer;

public class BusinessRules : IBusinessRules
{
    IDataAccess DataAccess = new DataAccess();

    public async Task<bool> AddGroup(string groupObject){
        try
        {
            var obj = JsonSerializer.Deserialize<Groups>(groupObject);
            DataAccess.AddGroups(obj);
            return true;
        }
        catch (Exception e)
        {
            // logg e?
            return false;
        }
    }

    public async Task<string> GetGroups(){
        try
        {
            List<Groups> result = await DataAccess.GetGroups();
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

    // TODO: Swap page and size to match datalayer method signature. Swap this signature as well and change in accesslayer.
    public async Task<string> GetGroups(int page, int size){
        try
        {
            Optional<List<Groups>> result = await DataAccess.GetGroups(page, size);
            if(!result.HasValue){
                return null;
            }
            return JsonSerializer.Serialize(DataAccess.GetGroups(page, size));
        }
        catch (Exception e)
        {
            // logg e?
            return null;
        }
    }
}
