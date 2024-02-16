using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meta_TV2_DataLayer;

[Table("slides")]
public class Slides
{
    [Key]
    [Column("slideid")]
    public int slideId {get; set;}
    [Column("groupid")]
    public int groupId {get; set;}
    [Column("groupindex")]
    public int groupIndex {get; set;}
    [Column("archive")]
    public bool archive {get; set;}
    [Column("archivedate")]
    public DateTime? archiveDate {get; set;}
}
