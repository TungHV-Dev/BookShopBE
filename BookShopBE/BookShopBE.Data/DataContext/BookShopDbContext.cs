using BookShopBE.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShopBE.Data.DataContext
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(bi => bi.AuthorId);

            modelBuilder.Entity<BookStore>()
                .HasOne(b => b.Book)
                .WithMany(bs => bs.BookStores)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<BookStore>()
                .HasOne(b => b.Store)
                .WithMany(bs => bs.BookStores)
                .HasForeignKey(bi => bi.StoreId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
