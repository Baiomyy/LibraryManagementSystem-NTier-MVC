namespace LibraryManagement.BLL.BookTransactionManagement.Dtos;

public class BorrowBookDto
{
    public int BookId { get; set; }
    public string BookTitle { get; set; } = default!;
    public DateTime BorrowedDate { get; set; }
}
