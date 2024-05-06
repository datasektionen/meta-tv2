using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meta_TV2_DataLayer;

public enum LogType{
    DEBUG,
    INFORMATION,
    WARNING,
    ERROR,
    CRITICAL
}

[Table("logging")]
public class Logging
{
    [Key]
    [Column("logid")]
    public int logId {get; set;}
    [Column("type")]
    public LogType type {get; set;}
    [Column("content")]
    public string content {get; set;}
    [Column("occuredin")]
    public string occuredIn {get; set;}
    [Column("dateandtime")]
    public DateTime dateAndTime {get; set;}
}
