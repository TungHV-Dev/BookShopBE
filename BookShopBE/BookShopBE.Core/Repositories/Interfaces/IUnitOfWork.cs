using System;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        IOrderRepository Sales { get; }
        ICustomerRepository Customers { get; }
        ICartRepository Carts { get; }
        IOrderRepository Orders { get; }
        IFeedbackRepository Feedbacks { get; }
        IUserRepository Users { get; }
        void Complete();
        Task CompleteAsync();
    }
}
