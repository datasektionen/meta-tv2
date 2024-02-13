using Microsoft.EntityFrameworkCore;

namespace Meta_TV2_DataLayer;

public class MetaTvContext : DbContext
{
    public DbSet<Blacklist> Blacklist {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Database=META-TV");
    }
}
