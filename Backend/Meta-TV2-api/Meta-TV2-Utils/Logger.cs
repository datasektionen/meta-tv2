using Microsoft.EntityFrameworkCore;

namespace Meta_TV2_Utils;

public class Logger : ILogger
{
    public void Log(LogLevels logLevel, string content, string occuredIn, DateTime dateAndTime){
        LogEntity log = new LogEntity{ logLevel = logLevel, content = content, occuredIn = occuredIn, dateAndTime = dateAndTime };
        StoreLog(log);
    }

    private async void StoreLog(LogEntity log){
        MetaTvUtilsContext db = new MetaTvUtilsContext();
        try {
            db.Add(log);
            await db.SaveChangesAsync();
            db.Dispose();
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}

public class MetaTvUtilsContext : DbContext
{
    public DbSet<LogEntity> Logging {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = UrlToConnectionString(Environment.GetEnvironmentVariable("DATABASE_URL")) ?? "Host=localhost;Database=META-TV";
        optionsBuilder.UseNpgsql(connectionString, npgsqlOptionsAction: sqlOptions =>
        {
            sqlOptions.CommandTimeout(10); // Timeout to 10 seconds
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    private static string UrlToConnectionString(string databaseUrl)
    {
        if (string.IsNullOrEmpty(databaseUrl))
        {
            return null;
        }

        var uri = new Uri(databaseUrl);

        var username = uri.UserInfo.Split(':')[0];
        var password = uri.UserInfo.Split(':')[1];
        var host = uri.Host;
        var port = uri.Port;
        var database = uri.AbsolutePath.Trim('/');

        return $"Host={host};Port={port};Username={username};Password={password};Database={database};";
    }
}
