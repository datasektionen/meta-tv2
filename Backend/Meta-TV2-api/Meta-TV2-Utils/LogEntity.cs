using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meta_TV2_Utils;

public enum LogLevels {
    DEBUG,
    INFORMATION,
    WARNING,
    ERROR,
    CRITICAL
}

[Table("logging")]
public class LogEntity
{
    [Key]
    [Column("logid")]
    public int logId {get; set;}
    [Column("loglevel")]
    public LogLevels logLevel {get; set;}
    [Column("content")]
    public string content {get; set;}
    [Column("occuredin")]
    public string occuredIn {get; set;}
    [Column("dateandtime")]
    public DateTime dateAndTime {get; set;}
}
