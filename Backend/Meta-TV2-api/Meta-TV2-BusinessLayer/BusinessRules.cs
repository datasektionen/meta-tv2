namespace Meta_TV2_BusinessLayer;

using System.Text.Json;
using Meta_TV2_DataLayer;

public class BusinessRules : IBusinessRules
{
    IDataAccess DataAccess = new DataAccess();

    public async Task<bool> AddGroup(string groupObject){
        try
        {
            // Convert string to a stream
            using var stream = new MemoryStream();
            using (var writer = new StreamWriter(stream, leaveOpen: true))
            {
                await writer.WriteAsync(groupObject);
                await writer.FlushAsync();
            }
            stream.Position = 0; // Reset the stream position to the beginning

            // Deserialize the JSON content from the stream asynchronously
            var obj = await JsonSerializer.DeserializeAsync<Groups>(stream);
            
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
            var data = await DataAccess.GetGroups();
            if (data.HasValue)
                return JsonSerializer.Serialize(data.Value);
            else return null;
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
            return JsonSerializer.Serialize(data.Value);
        else return null;
    }

    public async Task<bool> ArchiveGroup(int id){
        try
        {
            // Get the group by Id
            var group = await DataAccess.GetGroupById(id);
            
            // Modify the group attributes
            group.Value.archive = true;
            group.Value.archiveDate = DateTime.Now;

            // Update database
            DataAccess.UpdateGroup(group.Value);
            return true;
        }
        catch (Exception e)
        {
            // logg e?
            return false;
        }
    }

    public async Task<string> GetGroups(int page, int size){
        try
        {
            var data = await DataAccess.GetGroups(page, size);
            if(data.HasValue)
                return JsonSerializer.Serialize(data.Value);
            else return null;
        }
        catch (Exception e)
        {
            // logg e?
            return null;
        }
    }
}
