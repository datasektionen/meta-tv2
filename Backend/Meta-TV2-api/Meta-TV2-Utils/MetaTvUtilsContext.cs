using Microsoft.EntityFrameworkCore;

namespace Meta_TV2_Utils;

public class MetaTvUtilsContext : DbContext
{
    public DbSet<LogEntity> Logging {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Database=META-TV", npgsqlOptionsAction: sqlOptions =>
        {
            sqlOptions.CommandTimeout(10); // Timeout to 10 seconds
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}
