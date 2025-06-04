using LibraryManagement.BLL.AuthorManagement.Dtos;
using LibraryManagement.DAL.AuthorManagement.Repositories;
using LibraryManagement.Models;

namespace LibraryManagement.BLL.AuthorManagement.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<List<AuthorDto>> GetAllAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        return authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            FullName = a.FullName,
            Email = a.Email,
            Website = a.Website,
            Bio = a.Bio
        }).ToList();
    }

    public async Task<AuthorDto?> GetAuthorByIdAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author == null) return null;

        return new AuthorDto
        {
            Id = author.Id,
            FullName = author.FullName,
            Email = author.Email,
            Website = author.Website,
            Bio = author.Bio
        };
    }

    public async Task AddAuthorAsync(AuthorDto model)
    {
        var author = new Author
        {
            FullName = model.FullName,
            Email = model.Email,
            Website = model.Website,
            Bio = model.Bio
        };

        await _authorRepository.AddAsync(author);
    }

    public async Task UpdateAuthorAsync(int id, AuthorDto model)
    {
        var existingAuthor = await _authorRepository.GetByIdAsync(id);
        if (existingAuthor == null) return;

        existingAuthor.FullName = model.FullName;
        existingAuthor.Email = model.Email;
        existingAuthor.Website = model.Website;
        existingAuthor.Bio = model.Bio;

        await _authorRepository.UpdateAsync(existingAuthor);
    }

    public async Task DeleteAuthorAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author == null) return;

        await _authorRepository.DeleteAsync(author);
    }

    public async Task<bool> AuthorExistsByEmail(string email)
    {
        return await _authorRepository.ExistsByEmailAsync(email);
    }

    public async Task<bool> AuthorExistsByFullname(string fullname)
    {
        return await _authorRepository.ExistsByFullnameAsync(fullname);
    }
}

