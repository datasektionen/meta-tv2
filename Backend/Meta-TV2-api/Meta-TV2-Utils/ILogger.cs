namespace Meta_TV2_Utils;

public interface ILogger
{
    public void Log(LogLevels logLevel, string content, string occuredIn, DateTime dateAndTime);
}
