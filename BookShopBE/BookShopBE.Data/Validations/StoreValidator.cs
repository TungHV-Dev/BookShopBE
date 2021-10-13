using FluentValidation;
using BookShopBE.Data.Dtos;

namespace BookShopBE.Data.Validations
{
    public class StoreValidator : AbstractValidator<StoreDto>
    {
        public StoreValidator()
        {

        }
    }
}
