using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Meta_TV2_BusinessLayer;

public interface IBusinessRules
{
    public bool Test_AddGroups(string groupObject);
}
