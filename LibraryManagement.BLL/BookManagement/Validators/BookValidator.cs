using FluentValidation;
using LibraryManagement.BLL.BookManagement.Dtos;

namespace LibraryManagement.BLL.BookManagement.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .WithMessage("Title is required.");

            RuleFor(b => b.Genre)
                .IsInEnum()
                .WithMessage("Genre is required.");

            RuleFor(b => b.Description)
                .MaximumLength(300)
                .WithMessage("Description must be at most 300 characters.");

            RuleFor(b => b.AuthorId)
                .GreaterThan(0)
                .WithMessage("An author must be selected.");
        }
    }
}
