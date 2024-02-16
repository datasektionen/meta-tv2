using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meta_TV2_DataLayer;

[Table("groups")]
public class Groups
{
    [Key]
    [Column("groupid")]
    public int groupId {get; set;}
    [Column("title")]
    public string title {get; set;}
    [Column("priority")]
    public bool priority {get; set;}
    [Column("hidden")]
    public bool hidden {get; set;}
    [Column("createdby")]
    public string createdBy {get; set;}
    [Column("startdate")]
    public DateTime startDate {get; set;}
    [Column("enddate")]
    public DateTime? endDate {get; set;}
    [Column("archive")]
    public bool archive {get; set;}
    [Column("archivedate")]
    public DateTime? archiveDate {get; set;}
}
