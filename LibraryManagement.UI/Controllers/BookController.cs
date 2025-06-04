using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagement.BLL.BookManagement.Dtos;
using LibraryManagement.BLL.AuthorManagement.Services;
using LibraryManagement.BLL.BookManagement.Services;
using LibraryManagement.Models;

public class BookController : Controller
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;

    public BookController(IBookService bookService, IAuthorService authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _bookService.GetAllBooksAsync();
        return View(books);
    }

    public async Task<IActionResult> Create()
    {
        await PopulateAuthorListAsync();
        PopulateGenreList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BookDto book)
    {
        if (!ModelState.IsValid)
        {
            await PopulateAuthorListAsync();
            PopulateGenreList();
            return View(book);
        }

        await _bookService.AddBookAsync(book);
        return RedirectToAction(nameof(Index));
    }

    // GET: Book/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null) return NotFound();

        var authors = await _authorService.GetAllAuthorsAsync();
        ViewBag.Authors = new SelectList(authors, "Id", "FullName", book.AuthorId);

        return View(book);
    }

    // POST: Book/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BookDto model)
    {
        if (id != model.Id) return BadRequest();

        if (!ModelState.IsValid)
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            ViewBag.Authors = new SelectList(authors, "Id", "FullName", model.AuthorId);
            return View(model);
        }

        await _bookService.UpdateBookAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null)
            return NotFound();

        return View(book);
    }


    // POST: Handle delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateAuthorListAsync()
    {
        var authors = await _authorService.GetAllAuthorsAsync();
        ViewBag.AuthorList = authors.Select(a => new SelectListItem
        {
            Text = a.FullName,
            Value = a.Id.ToString()
        });
    }
    private void PopulateGenreList()
    {
        var genres = Enum.GetValues(typeof(Genre))
                         .Cast<Genre>()
                         .Select(g => new SelectListItem
                         {
                             Text = g.ToString(),
                             Value = g.ToString()
                         });

        ViewBag.GenreList = genres;
    }
}
