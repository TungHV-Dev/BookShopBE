using BookShopBE.Data.Dtos;
using FluentValidation;

namespace BookShopBE.Data.Validations
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(book => book.Name).NotEmpty().WithMessage("Book's name is required");
            RuleFor(book => book.Name).MaximumLength(100);
        }
    }
}
