using LibraryManagement.DAL.Persistence;

namespace LibraryManagement.DAL.Seeders;

public interface IDbSeeder
{
    void Seed(LibraryDbContext context);
}
