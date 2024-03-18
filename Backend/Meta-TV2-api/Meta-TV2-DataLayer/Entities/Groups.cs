using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Meta_TV2_DataLayer;

[Table("groups")]
public class Groups
{
    [Key]
    [Column("groupid")]
    public int groupId {get; set;}
    [JsonRequired]
    [Column("title")]
    public string title {get; set;}
    [JsonRequired]
    [Column("priority")]
    public bool priority {get; set;}
    [JsonRequired]
    [Column("hidden")]
    public bool hidden {get; set;}
    [JsonRequired]
    [Column("createdby")]
    public string createdBy {get; set;}
    [JsonRequired]
    [Column("startdate")]
    public DateTime startDate {get; set;}
    [Column("enddate")]
    public DateTime? endDate {get; set;}
    [JsonRequired]
    [Column("archive")]
    public bool archive {get; set;}
    [Column("archivedate")]
    public DateTime? archiveDate {get; set;}
}
