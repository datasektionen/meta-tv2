using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Meta_TV2_DataLayer;

[Table("changes")]
public class Changes
{
    [Key]
    [Column("changeid")]
    public int changeId {get; set;}
    [JsonRequired]
    [Column("groupid")]
    public int groupId {get; set;}
    [JsonRequired]
    [Column("changedby")]
    public string changedBy {get; set;}
    [JsonRequired]
    [Column("changetype")]
    public string changeType {get; set;}
    [JsonRequired]
    [Column("changedslideid")]
    public int changedSlideId {get; set;}
    [JsonRequired]
    [Column("changedate")]
    public DateTime changeDate {get; set;}
}
