using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(BookShopDbContext context)
        {
            _context = context;

            Authors = new AuthorRepository(_context);
            Books = new BookRepository(_context);
            Stores = new StoreRepository(_context);
            Sales = new OrderRepository(_context);
        }

        private readonly BookShopDbContext _context;
        public IAuthorRepository Authors { get; private set; }
        public IBookRepository Books { get; private set; }
        public IStoreRepository Stores { get; private set; }
        public IOrderRepository Sales { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
