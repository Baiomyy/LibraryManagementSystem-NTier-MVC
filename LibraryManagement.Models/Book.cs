using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = default!;
    [Required]
    public Genre Genre { get; set; }
    [MaxLength(300)]
    public string? Description { get; set; }

    // Foreign key property for Author
    [Required]
    public int AuthorId { get; set; }

    // Navigation property for Author
    public virtual Author Author { get; set; } = default!;
    public virtual ICollection<BookTransaction> BookTransactions { get; set; } = new List<BookTransaction>();

}