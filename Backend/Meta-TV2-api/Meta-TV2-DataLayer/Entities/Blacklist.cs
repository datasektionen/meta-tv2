using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Meta_TV2_DataLayer;

[Table("blacklist")]
public class Blacklist
{
    [Key]
    [JsonRequired]
    [Column("alias")]
    public string alias {get; set;}
}
