using BookShopBE.Data.Configurations;
using BookShopBE.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShopBE.Data.DataContext
{
    public class BookShopDbContext : IdentityDbContext<User>
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerHasOrder> CustomerHasOrders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());

            modelBuilder.Entity<BookAuthor>()
                .HasOne(book_author => book_author.Book)
                .WithMany(book => book.BookAuthors)
                .HasForeignKey(book_author => book_author.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(book_author => book_author.Author)
                .WithMany(book => book.BookAuthors)
                .HasForeignKey(book_author => book_author.AuthorId);

            modelBuilder.Entity<Feedback>()
                .HasOne(feedback => feedback.Customer)
                .WithMany(customer => customer.Feedbacks)
                .HasForeignKey(feedback => feedback.CustomerId);

            modelBuilder.Entity<Feedback>()
                .HasOne(feedback => feedback.Book)
                .WithMany(book => book.Feedbacks)
                .HasForeignKey(feedback => feedback.BookId);

            modelBuilder.Entity<Cart>()
                .HasOne(cart => cart.User)
                .WithMany(user => user.Carts)
                .HasForeignKey(cart => cart.UserId);

            modelBuilder.Entity<Cart>()
                .HasOne(cart => cart.Book)
                .WithMany(book => book.Carts)
                .HasForeignKey(cart => cart.BookId);

            modelBuilder.Entity<Order>()
                .HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(order => order.CustomerId);

            modelBuilder.Entity<Order>()
                .HasOne(order => order.Book)
                .WithMany(book => book.Orders)
                .HasForeignKey(order => order.BookId);
        }
    }
}
