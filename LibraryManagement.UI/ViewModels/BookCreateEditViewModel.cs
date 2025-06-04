using LibraryManagement.BLL.BookManagement.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.UI.ViewModels;

public class BookCreateEditViewModel
{
    public BookDto Book { get; set; }
    [BindNever] // ✅ Prevents model binding and validation
    public IEnumerable<SelectListItem> Authors { get; set; }
}