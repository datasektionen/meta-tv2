using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meta_TV2_DataLayer;

[Table("posts")]
public class Posts
{
    [Key]
    [Column("postid")]
    public int postId {get; set;}
    [Column("filepath")]
    public string filePath {get; set;}
    [Column("pathtype")]
    public string pathType {get; set;}
    [Column("tvindex")]
    public int tvIndex {get; set;}
    [Column("slideid")]
    public int slideId {get; set;}
}
