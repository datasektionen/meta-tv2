namespace Meta_TV2_Utils;

public class Logger : ILogger
{
    public void Log(LogLevels logLevel, string content, string occuredIn, DateTime dateAndTime){
        LogEntity log = new LogEntity{ logLevel = logLevel, content = content, occuredIn = occuredIn, dateAndTime = dateAndTime };
        StoreLog(log);
    }

    private async void StoreLog(LogEntity log){
        MetaTvUtilsContext db = new MetaTvUtilsContext();
        db.Add(log);
        await db.SaveChangesAsync();
        db.Dispose();
    }
}
