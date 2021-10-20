using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(BookShopDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

            Authors = new AuthorRepository(_context);
            Books = new BookRepository(_context);
            Sales = new OrderRepository(_context);
            Customers = new CustomerRepository(_context);
            Carts = new CartRepository(_context);
            Orders = new OrderRepository(_context);
            Feedbacks = new FeedbackRepository(_context);
            Users = new UserRepository(_context, _userManager);
        }

        private readonly BookShopDbContext _context;
        private readonly UserManager<User> _userManager;
        public IAuthorRepository Authors { get; private set; }
        public IBookRepository Books { get; private set; }
        public IOrderRepository Sales { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public ICartRepository Carts { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IFeedbackRepository Feedbacks { get; private set; }
        public IUserRepository Users { get; private set; }

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
