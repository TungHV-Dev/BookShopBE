using BookShopBE.Common.Constants;
using BookShopBE.Data.Dtos.Authentications;
using BookShopBE.Data.Dtos.Books;
using BookShopBE.Data.Dtos.Feedbacks;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BookShopBE.Data.Validations
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(book => book.Name).NotEmpty().WithMessage("Book's name is required");
            RuleFor(book => book.Name).MaximumLength(100).WithMessage("The max length of book's name is 100 characters");
            RuleFor(book => book.Name).MinimumLength(10).WithMessage("The min length of book's name is 10 characters");
        }
    }

    public class FeedbackMessageDtoValidator : AbstractValidator<FeedbackRequest>
    {
        public FeedbackMessageDtoValidator()
        {
            RuleFor(feedback => feedback.Message).NotEmpty().WithMessage("Feedback message is not empty");
            RuleFor(feedback => feedback.Message).NotNull().WithMessage("Feedback message is not null");
        }
    }

    public class RateStarDtoValidator : AbstractValidator<RateStarRequest>
    {
        public RateStarDtoValidator()
        {
            RuleFor(dto => dto.StarRate).GreaterThanOrEqualTo(1).LessThanOrEqualTo(5);
        }
    }
}
