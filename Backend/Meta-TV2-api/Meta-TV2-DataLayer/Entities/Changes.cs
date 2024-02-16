using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meta_TV2_DataLayer;

[Table("changes")]
public class Changes
{
    [Key]
    [Column("changeid")]
    public int changeId {get; set;}
    [Column("groupid")]
    public int groupId {get; set;}
    [Column("changedby")]
    public string changedBy {get; set;}
    [Column("changetype")]
    public string changeType {get; set;}
    [Column("changedslideid")]
    public int changedSlideId {get; set;}
    [Column("changedate")]
    public DateTime changeDate {get; set;}
}
