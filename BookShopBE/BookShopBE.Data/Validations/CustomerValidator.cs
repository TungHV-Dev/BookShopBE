using FluentValidation;
using BookShopBE.Data.Dtos;
using BookShopBE.Data.Models;

namespace BookShopBE.Data.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {

        }
    }
}
