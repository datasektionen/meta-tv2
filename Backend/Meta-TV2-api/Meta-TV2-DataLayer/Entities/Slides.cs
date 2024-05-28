using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Meta_TV2_DataLayer;

[Table("slides")]
public class Slides
{
    [Key]
    [Column("slideid")]
    public int slideId {get; set;}
    [JsonRequired]
    [Column("groupid")]
    public int groupId {get; set;}
    [JsonRequired]
    [Column("groupindex")]
    public int groupIndex {get; set;}
    [JsonRequired]
    [Column("archive")]
    public bool archive {get; set;}
    [Column("archivedate")]
    public DateTime? archiveDate {get; set;}
}
