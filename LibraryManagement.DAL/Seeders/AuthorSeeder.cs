using LibraryManagement.DAL.Persistence;
using LibraryManagement.DAL.Seeders;
using LibraryManagement.Models;

public class AuthorSeeder : IDbSeeder
{
    public void Seed(LibraryDbContext context)
    {
        if (!context.Authors.Any())
        {
            context.Authors.AddRange(
                new Author { FullName = "Ahmed Ali Hassan Omar", Email = "ahmed@example.com", Website = "https://ahmed.com", Bio = "Specializes in historical fiction." },
                new Author { FullName = "Sara Mohamed Fathy Hamed", Email = "sara@example.com", Website = "https://sara.com", Bio = "Writes romance and adventure stories." }
            );
            context.SaveChanges();
        }
    }
}
