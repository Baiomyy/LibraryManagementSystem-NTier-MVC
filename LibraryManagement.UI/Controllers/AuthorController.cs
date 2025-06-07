using LibraryManagement.BLL.AuthorManagement.Dtos;
using LibraryManagement.BLL.AuthorManagement.Services;
using LibraryManagement.BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.UI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var authors = await _authorService.GetAllAuthorsAsync();
        //    ViewBag.Authors = authors;
        //    return View(authors);
        //}
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var (authors, totalCount) = await _authorService.GetPagedAuthorsAsync(page, pageSize);

            ViewBag.TotalCount = totalCount;
            ViewBag.PageSize = pageSize;
            ViewBag.CurrentPage = page;

            return View(authors);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _authorService.AddAuthorAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.ErrorMessage);
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
                return NotFound();

            var dto = new AuthorDto
            {
                FullName = author.FullName,
                Email = author.Email,
                Website = author.Website,
                Bio = author.Bio
            };

            return View(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, AuthorDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _authorService.UpdateAuthorAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.ErrorMessage);
                return View(model);
            }
        }


        
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
                return NotFound();

            return View(author); 
        }


        // POST: Handle delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
