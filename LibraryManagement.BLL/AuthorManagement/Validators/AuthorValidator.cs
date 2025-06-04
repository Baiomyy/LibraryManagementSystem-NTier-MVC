using FluentValidation;
using LibraryManagement.Models;

namespace LibraryManagement.BLL.AuthorManagement.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.FullName)
                .NotEmpty()
                .Must(HaveFourNamesWithMinTwoChars)
                .WithMessage("Full name must consist of four names, each at least 2 characters long.");

            RuleFor(a => a.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email must be in a valid format.");

            RuleFor(a => a.Bio)
                .MaximumLength(300);
        }

        private bool HaveFourNamesWithMinTwoChars(string fullName)
        {
            var names = fullName?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return names is { Length: 4 } && names.All(n => n.Length >= 2);
        }
    }
}
