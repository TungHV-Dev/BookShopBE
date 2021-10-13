using FluentValidation;
using BookShopBE.Data.Dtos;

namespace BookShopBE.Data.Validations
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {

        }
    }
}
