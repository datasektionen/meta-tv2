namespace Meta_TV2_BusinessLayer;

using System.Text.Json;
using Meta_TV2_DataLayer;

public class BusinessRules : IBusinessRules
{
    IDataAccess DataAccess = new DataAccess();

    public bool Test_AddGroups(string groupObject){
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
}
