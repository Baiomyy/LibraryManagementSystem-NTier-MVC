using LibraryManagement.Models;

namespace LibraryManagement.UI.ViewModels;

public class BookStatusViewModel
{
    public int BookId { get; set; }
    public string Title { get; set; } = "";
    public string AuthorFullName { get; set; } = "";
    public string Genre { get; set; } = "";
    public string Status { get; set; } = ""; // Borrowed / Available
    public DateTime? BorrowedDate { get; set; }
    public DateTime? ReturnedDate { get; set; }
    public int? TransactionId { get; set; }
}
