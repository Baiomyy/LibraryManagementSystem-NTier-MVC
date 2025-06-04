using LibraryManagement.DAL.Persistence;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DAL.AuthorManagement.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext _context;

    public AuthorRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Author>> GetAllAsync()
    {
        return await _context.Authors.AsNoTracking().ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _context.Authors
                             .Include(a => a.Books) // Include related books if needed
                             .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Author author)
    {
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Author author)
    {
        _context.Authors.Update(author);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Author author)
    {
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Authors.AnyAsync(a => a.Email == email);
    }

    public async Task<bool> ExistsByFullnameAsync(string fullname)
    {
        return await _context.Authors.AnyAsync(a => a.FullName == fullname);
    }
}

