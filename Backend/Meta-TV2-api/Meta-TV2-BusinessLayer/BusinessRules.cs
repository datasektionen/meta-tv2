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

    public async Task<string> GetGroups(int page, int size){
        try
        {
            var result = await DataAccess.GetGroups(page, size);
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


    public async Task<string> GetSlides() {
        try
        {
            var result = await DataAccess.GetSlides();
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
            var result = await DataAccess.GetSlidesByGroup(groupId);
            if(!result.HasValue) 
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch (Exception e) {
            return null;
        }
    }

    public async Task<string> GetSlideById(int id) {
        try{
            var result = await DataAccess.GetSlideById(id);
            if(!result.HasValue)
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch(Exception e) {
            return null;
        }
    }

    public async Task<string> GetSlidesByGroup(int groupId, int page, int size) {
        try {
            var result = await DataAccess.GetSlidesByGroup(groupId, page, size);
            if(!result.HasValue) 
                return null;
            return JsonSerializer.Serialize(result.Value);
        } catch(Exception e){
            return null;
        }
    }

    public async Task<bool> AddSlide(string slideObject){
        try {
            var slide = JsonSerializer.Deserialize<Slides>(slideObject);
            DataAccess.AddSlide(slide);
            return true;
        } catch(Exception e) {
            return false;
        }
    }

    public async Task<bool> ArchiveSlide(int id) {
        try {
            var slide = await DataAccess.GetSlideById(id);
            if (!slide.HasValue) 
                return false;
            slide.Value.archive = true;
            slide.Value.archiveDate = DateTime.Now;
            DataAccess.UpdateSlide(slide.Value);
            return true;
        } catch(Exception e) {
            return false;
        }
    }
}