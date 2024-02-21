using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Meta_TV2_BusinessLayer;

public interface IBusinessRules
{
    public bool AddGroup(string groupObject);

    public string GetGroupsTest();

    public Task<string> GetGroupById(int id);

    public Task<bool> ArchiveGroup(int id);

    public string GetGroups(int page, int size);

}
