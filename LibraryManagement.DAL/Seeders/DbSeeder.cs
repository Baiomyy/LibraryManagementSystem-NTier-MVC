using LibraryManagement.DAL.Persistence;
using LibraryManagement.DAL.Seeders;

public class DbSeeder
{
    private readonly IEnumerable<IDbSeeder> _seeders;

    public DbSeeder(IEnumerable<IDbSeeder> seeders)
    {
        _seeders = seeders;
    }

    public void SeedAll(LibraryDbContext context)
    {
        foreach (var seeder in _seeders)
        {
            seeder.Seed(context);
        }
    }
}
