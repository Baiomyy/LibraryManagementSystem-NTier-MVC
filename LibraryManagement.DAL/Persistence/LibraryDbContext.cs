using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DAL.Persistence;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {

    }
    public DbSet<Author> Authors { get; set; } 
    public DbSet<Book> Books { get; set; } 
    public DbSet<BookTransaction> BookTransactions { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasIndex(a => a.FullName).IsUnique();
            entity.HasIndex(a => a.Email).IsUnique();

            entity.Property(a => a.FullName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(a => a.Email)
                  .IsRequired();

            entity.Property(a => a.Bio)
                  .HasMaxLength(300);
        });
    }

}
