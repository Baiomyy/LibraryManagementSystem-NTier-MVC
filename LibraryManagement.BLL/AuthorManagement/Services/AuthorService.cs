using LibraryManagement.BLL.AuthorManagement.Dtos;
using LibraryManagement.BLL.Exceptions;
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
        // Validate FullName format (four names with min 2 chars each)
        if (!HaveFourNamesWithMinTwoChars(model.FullName))
        {
            throw new ValidationException(nameof(model.FullName), "Full name must consist of four names, each at least 2 characters long.");
        }

        // Validate uniqueness
        if (await _authorRepository.ExistsByFullnameAsync(model.FullName))
        {
            throw new ValidationException(nameof(model.FullName), "Full name must be unique.");
        }

        if (await _authorRepository.ExistsByEmailAsync(model.Email))
        {
            throw new ValidationException(nameof(model.Email), "Email must be unique.");
        }

        var author = new Author
        {
            FullName = model.FullName,
            Email = model.Email,
            Website = model.Website,
            Bio = model.Bio
        };

        await _authorRepository.AddAsync(author);
    }

    private bool HaveFourNamesWithMinTwoChars(string fullName)
    {
        var names = fullName?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return names is { Length: 4 } && names.All(n => n.Length >= 2);
    }


    public async Task UpdateAuthorAsync(int id, AuthorDto model)
    {
        var existingAuthor = await _authorRepository.GetByIdAsync(id);
        if (existingAuthor == null)
            throw new Exception("Author not found");

        // ✅ Validate full name structure
        var names = model.FullName?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (names is not { Length: 4 } || names.Any(n => n.Length < 2))
            throw new ValidationException(nameof(model.FullName), "Full name must consist of four names, each at least 2 characters long.");

        // ✅ Check uniqueness — exclude current record
        if (await _authorRepository.ExistsByFullnameAsync(model.FullName) && model.FullName != existingAuthor.FullName)
            throw new ValidationException(nameof(model.FullName), "Full name must be unique.");

        if (await _authorRepository.ExistsByEmailAsync(model.Email) && model.Email != existingAuthor.Email)
            throw new ValidationException(nameof(model.Email), "Email must be unique.");

        // ✅ Update values
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

