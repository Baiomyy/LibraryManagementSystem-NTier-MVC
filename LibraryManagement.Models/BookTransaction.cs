using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models;

public class BookTransaction
{
    public int Id { get; set; }

    // Foreign key to Book
    [Required]
    public int BookId { get; set; }

    public virtual Book Book { get; set; } = default!;
    [Required]

    public DateTime BorrowedDate { get; set; }

    public DateTime? ReturnedDate { get; set; }

    //Check if the book is returned
    public bool IsReturned => ReturnedDate.HasValue;
}