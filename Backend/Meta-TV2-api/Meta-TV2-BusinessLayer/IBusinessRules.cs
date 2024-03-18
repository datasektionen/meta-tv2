using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Meta_TV2_BusinessLayer;

public interface IBusinessRules
{
    public Task<bool> AddGroup(string groupObject);

    public Task<string> GetGroups();

    public Task<string> GetGroupById(int id);

    public Task<bool> ArchiveGroup(int id);

    public Task<string> GetGroups(int page, int size);

}
