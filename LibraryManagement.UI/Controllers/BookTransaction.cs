using LibraryManagement.BLL.BookManagement.Services;
using LibraryManagement.BLL.BookTransactionManagement.Dtos;
using LibraryManagement.BLL.BookTransactionManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

//public class BookTransactionController : Controller
//{
//    private readonly IBookTransactionService _service;
//    private readonly IBookService _bookService;

//    public BookTransactionController(IBookTransactionService service, IBookService bookService)
//    {
//        _service = service;
//        _bookService = bookService;
//    }

//    // GET: BookTransaction
//    public async Task<IActionResult> Index(string? status, DateTime? borrowDate, DateTime? returnDate)
//    {
//        var transactions = await _service.GetAllAsync(status, borrowDate, returnDate);
//        return View(transactions);
//    }

//    // GET: BookTransaction/Borrow?bookId=1
//    [HttpGet]
//    //public IActionResult Borrow(int bookId)
//    //{
//    //    //ViewBag.BookId = bookId;
//    //    //return View();
//    //}
//        [HttpGet]
//        public IActionResult Borrow(int bookId)
//        {
//            var book = _bookService.GetBookByIdAsync(bookId);
//            if (book == null)
//            {
//                return NotFound(); // avoid null exception
//            }

//            var dto = new BorrowBookDto
//            {
//                BookId = book.Result!.Id,
//                BookTitle = book.Result.Title,
//                BorrowedDate = DateTime.Today
//            };

//            return View(dto);
//        }

//    // POST: BookTransaction/Borrow
//    [HttpPost, ActionName("Borrow")]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> BorrowConfirmed(int bookId)
//    {
//        try
//        {
//            await _service.BorrowAsync(bookId);
//            return RedirectToAction(nameof(Index));
//        }
//        catch (InvalidOperationException ex)
//        {
//            ModelState.AddModelError(string.Empty, ex.Message);
//            ViewBag.BookId = bookId;
//            return View("Borrow");
//        }
//    }

//    // POST: BookTransaction/Return
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Return(int transactionId)
//    {
//        try
//        {
//            await _service.ReturnAsync(transactionId);
//            return RedirectToAction(nameof(Index));
//        }
//        catch (InvalidOperationException ex)
//        {
//            TempData["Error"] = ex.Message;
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}

public class BookTransactionController : Controller
{
    private readonly IBookTransactionService _transactionService;
    private readonly IBookService _bookService;

    public BookTransactionController(IBookTransactionService transactionService, IBookService bookService)
    {
        _transactionService = transactionService;
        _bookService = bookService;
    }

    //GET: BookTransaction
    public async Task<IActionResult> Index(string? status, DateTime? borrowDate, DateTime? returnDate, int pageNumber = 1)
    {
        int pageSize = 10;  
        var (transactions, totalCount) = await _transactionService.GetPagedAsync(pageNumber, pageSize, status, borrowDate, returnDate);

        ViewData["TotalCount"] = totalCount;
        ViewData["PageNumber"] = pageNumber;
        ViewData["PageSize"] = pageSize;

        return View(transactions);
    }




    // GET: BookTransaction/Borrow?bookId=1
    [HttpGet]
    public async Task<IActionResult> Borrow(int bookId)
    {
        var book = await _bookService.GetBookByIdAsync(bookId);
        if (book == null)
            return NotFound();

        // Check if book is already borrowed
        var latestTransaction = await _transactionService.GetTransactionByBookIdAsync(bookId);
        if (latestTransaction != null && latestTransaction.ReturnedDate == null)
        {
            TempData["Error"] = "This book is already borrowed.";
            return RedirectToAction(nameof(Index));
        }

        var dto = new BorrowBookDto
        {
            BookId = book.Id,
            BookTitle = book.Title,
            BorrowedDate = DateTime.Today
        };

        return View(dto);
    }

    // POST: BookTransaction/Borrow
    [HttpPost, ActionName("Borrow")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BorrowConfirmed(int bookId)
    {
        try
        {
            await _transactionService.BorrowAsync(bookId);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);

            var book = await _bookService.GetBookByIdAsync(bookId);
            if (book == null)
                return NotFound();

            var dto = new BorrowBookDto
            {
                BookId = book.Id,
                BookTitle = book.Title,
                BorrowedDate = DateTime.Today
            };

            return View(dto);
        }
    }

    // POST: BookTransaction/Return
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Return(int transactionId)
    {
        try
        {
            await _transactionService.ReturnAsync(transactionId);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}