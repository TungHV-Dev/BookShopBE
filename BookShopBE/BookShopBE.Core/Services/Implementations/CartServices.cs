using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Implementations
{
    public class CartServices : ICartServices
    {
        private IUnitOfWork _unitOfWork;

        public CartServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddBookToCart(int customerId, int bookId)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAllBookFromCart(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteBookFromCart(int customerId, int bookId)
        {
            throw new System.NotImplementedException();
        }
    }
}
