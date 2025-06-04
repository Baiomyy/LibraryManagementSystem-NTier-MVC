using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models;

public class Author
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = default!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;
    [Url]
    public string? Website { get; set; }
    [MaxLength(300)]
    public string? Bio { get; set; }

    // Navigation property: read-only list of books by this author
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
