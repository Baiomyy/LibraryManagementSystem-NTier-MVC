using LibraryManagement.Models;

namespace LibraryManagement.DAL.AuthorManagement.Repositories;

public interface IAuthorRepository
{
    Task<List<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    Task AddAsync(Author author);
    Task UpdateAsync(Author author);
    Task DeleteAsync(Author author);
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByFullnameAsync(string fullname);
    Task<(List<Author>, int totalCount)> GetPagedAuthorsAsync(int page, int pageSize);

}
