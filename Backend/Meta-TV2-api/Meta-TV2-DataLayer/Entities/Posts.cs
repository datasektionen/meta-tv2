using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Meta_TV2_DataLayer;

[Table("posts")]
public class Posts
{
    [Key]
    [Column("postid")]
    public int postId {get; set;}
    [Column("filepath")]
    public string filePath {get; set;}
    [JsonRequired]
    [Column("pathtype")]
    public string pathType {get; set;}
    [JsonRequired]
    [Column("tvindex")]
    public int tvIndex {get; set;}
    [JsonRequired]
    [Column("slideid")]
    public int slideId {get; set;}
}
