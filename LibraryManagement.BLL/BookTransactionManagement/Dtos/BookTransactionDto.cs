namespace LibraryManagement.BLL.BookTransactionManagement.Dtos;

public class BookTransactionDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public DateTime BorrowedDate { get; set; }
    public DateTime? ReturnedDate { get; set; }
    public bool IsReturned => ReturnedDate.HasValue;
}