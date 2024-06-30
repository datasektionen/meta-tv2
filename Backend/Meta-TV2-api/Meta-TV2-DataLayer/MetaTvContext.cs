using Microsoft.EntityFrameworkCore;

namespace Meta_TV2_DataLayer;

public class MetaTvContext : DbContext
{
    public DbSet<Posts> Posts {get; set;}
    public DbSet<Slides> Slides {get; set;}
    public DbSet<Groups> Groups {get; set;}
    public DbSet<Changes> Changes {get; set;}
    public DbSet<Blacklist> Blacklist {get; set;}
    
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
