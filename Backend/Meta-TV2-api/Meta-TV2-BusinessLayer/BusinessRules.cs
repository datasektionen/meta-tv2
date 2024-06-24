namespace Meta_TV2_BusinessLayer;

using System.Text.Json;
using Meta_TV2_DataLayer;

public class BusinessRules : IBusinessRules
{
    IDataAccess dataAccess = new DataAccess();

    public async Task<Optional<Blacklist>> GetBlacklistByAlias(string alias){
        return await dataAccess.GetBlacklistByAlias(alias);
    }

    public bool BanUser(string alias){
        try {
            var blacklist = JsonSerializer.Deserialize<Blacklist>(alias);
            dataAccess.AddBlacklist(blacklist);
            return true;
        } 
        catch(Exception e) {
            Console.WriteLine(e);
            return false;
        }
    }
    public async Task<string> GetBlacklistedUsers() {
        try
        {
            var result = await dataAccess.GetBlacklistedUsers();
            if(!result.HasValue) 
                return "";
            return JsonSerializer.Serialize(result.Value);
        }
        catch (Exception e)
        {  
            //logg e?
            return null;
        }
    }

    public async Task<bool> UnbanUser(string alias) {
        try {
            var entry = await dataAccess.GetBlacklistByAlias(alias);
            if(entry.HasValue) {
                dataAccess.RemoveFromBlacklist(entry.Value);
                return true;
            }
            return false;
        }
        catch (Exception e) {
            //logg e?
            return false;
        }
    }

    public bool AddGroup(Groups groupObject){
        try
        {
            dataAccess.AddGroups(groupObject);
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
            var data = await dataAccess.GetGroups();
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

    // TODO: Add try-catch
    public async Task<string> GetGroupById(int id){
        var data = await dataAccess.GetGroupById(id);
        if (data.HasValue)
            return JsonSerializer.Serialize(data.Value);
        else return null;
    }

    public async Task<bool> ArchiveGroup(int id){
        try
        {
            // Get the group by Id
            var group = await dataAccess.GetGroupById(id);
            
            // Modify the group attributes
            group.Value.archive = true;
            group.Value.archiveDate = DateTime.Now;

            // Update database
            dataAccess.UpdateGroup(group.Value);
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
            var data = await dataAccess.GetGroups(page, size);
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

    public async Task<string> GetSlides() {
        try
        {
            var result = await dataAccess.GetSlides();
            if(!result.HasValue) 
                return null;
            return JsonSerializer.Serialize(result.Value);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<string> GetSlidesByGroup(int groupId) {
        try {
            var result = await dataAccess.GetSlidesByGroup(groupId);
            if(!result.HasValue) 
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch (Exception e) {
            return null;
        }
    }

    public async Task<string> GetSlideById(int id) {
        try{
            var result = await dataAccess.GetSlideById(id);
            if(!result.HasValue)
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch(Exception e) {
            return null;
        }
    }

    public async Task<string> GetSlidesByGroup(int groupId, int page, int size) {
        try {
            var result = await dataAccess.GetSlidesByGroup(groupId, page, size);
            if(!result.HasValue) 
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch(Exception e){
            return null;
        }
    }

    public bool AddSlide(Slides slideObject){
        try {
            dataAccess.AddSlide(slideObject);
            return true;
        } catch(Exception e) {
            return false;
        }
    }

    public async Task<bool> ArchiveSlide(int id) {
        try {
            var slide = await dataAccess.GetSlideById(id);
            if (!slide.HasValue) 
                return false;
            slide.Value.archive = true;
            slide.Value.archiveDate = DateTime.Now;
            dataAccess.UpdateSlide(slide.Value);
            return true;
        } catch(Exception e) {
            return false;
        }
    }
}
