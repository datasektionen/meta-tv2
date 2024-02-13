namespace Meta_TV2_BusinessLayer;

using Meta_TV2_DataLayer;

public class BusinessRules : IBusinessRules
{
    IDataAccess DataAccess = new DataAccess();
    
    public void TestMethod(string Name){
        DataAccess.TestData(Name);
    }

    public string getFirstAlphabetical(){
        return DataAccess.getFirstAlphabetical();
    }
}
