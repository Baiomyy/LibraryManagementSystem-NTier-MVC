using LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.BLL.BookManagement.Dtos;

public class BookDto
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = default!;

    [Required]
    public Genre Genre { get; set; }

    [MaxLength(300)]
    public string? Description { get; set; }

    [Required]
    public int AuthorId { get; set; }

    public string? AuthorFullName { get; set; } // for display only
}
