using LibraryManagement.BLL.AuthorManagement.Dtos;

namespace LibraryManagement.BLL.AuthorManagement.Services;

public interface IAuthorService
{
    Task<List<AuthorDto>> GetAllAuthorsAsync();
    Task<AuthorDto?> GetAuthorByIdAsync(int id);
    Task AddAuthorAsync(AuthorDto model);
    Task UpdateAuthorAsync(int id, AuthorDto model);
    Task DeleteAuthorAsync(int id);
    Task<bool> AuthorExistsByEmail(string email);
    Task<bool> AuthorExistsByFullname(string fullname);
}