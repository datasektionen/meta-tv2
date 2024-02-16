using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meta_TV2_DataLayer;

[Table("blacklist")]
public class Blacklist
{
    [Key]
    [Column("alias")]
    public string alias {get; set;}
}
