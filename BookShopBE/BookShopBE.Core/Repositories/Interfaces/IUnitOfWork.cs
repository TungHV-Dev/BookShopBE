using System;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        IStoreRepository Stores { get; }
        IOrderRepository Sales { get; }
        void Complete();
        Task CompleteAsync();
    }
}
