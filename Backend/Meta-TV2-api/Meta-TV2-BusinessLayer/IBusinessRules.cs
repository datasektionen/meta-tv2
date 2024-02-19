using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Meta_TV2_BusinessLayer;

public interface IBusinessRules
{
    public bool AddGroup(string groupObject);

    public string GetGroups();

    public string GetGroupById(int id);

    public bool ArchiveGroup(int id);

}
