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
        optionsBuilder.UseNpgsql(@"Host=localhost;Database=META-TV", npgsqlOptionsAction: sqlOptions =>
        {
            sqlOptions.CommandTimeout(10); // Timeout to 10 seconds
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}
