using BookShopBE.Common.Repository;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Dtos.Authors;
using BookShopBE.Data.Dtos.Books;
using BookShopBE.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Implementations
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        private readonly BookShopDbContext dbContext;
        public BookRepository(BookShopDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task Add(AddBookRequest request)
        {
            var book = new Book()
            {
                Name = request.bookDto.Name,
                Description = request.bookDto.Description,
                Rate = request.bookDto.Rate,
                Genre = request.bookDto.Genre,
                Quantity = request.bookDto.Quantity,
                Price = request.bookDto.Price,
                Url = request.bookDto.Url,
                PublisherName = request.bookDto.PublisherName,
                CreatedDate = request.CreatedDate,
                CreatedBy = request.CreatedBy
            };
            dbContext.Books.Add(book);

            if (request.IsAddAuthors)
            {
                foreach (int authorId in request.AuthorIds)
                {
                    var book_author = new BookAuthor()
                    {
                        BookId = book.Id,
                        AuthorId = authorId
                    };
                    dbContext.BookAuthors.Add(book_author);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task Update(UpdateBookRequest request)
        {
            var book = await dbContext.Books.FindAsync(request.bookId);
            book.Name = request.bookDto.Name;
            book.Description = request.bookDto.Description;
            book.Rate = request.bookDto.Rate;
            book.Genre = request.bookDto.Genre;
            book.Quantity = request.bookDto.Quantity;
            book.Price = request.bookDto.Price;
            book.Url = request.bookDto.Url;
            book.PublisherName = request.bookDto.PublisherName;
            book.ModifiedDate = request.ModifiedDate;
            book.ModifiedBy = request.ModifiedBy;

            if (request.IsUpdateAuthors)
            {
                var ListBookAuthor = await dbContext.BookAuthors.Where(x => x.BookId == request.bookId).ToListAsync();
                dbContext.BookAuthors.RemoveRange(ListBookAuthor);

                foreach (int id in request.AuthorIds)
                {
                    var book_author = new BookAuthor()
                    {
                        BookId = request.bookId,
                        AuthorId = id
                    };
                    dbContext.BookAuthors.Add(book_author);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<BookResponse<AuthorDto>> GetAuthorsOfBook(int bookId)
        {
            var book = await dbContext.Books.FindAsync(bookId);
            var _bookDto = new BookDto()
            {
                Name = book.Name,
                Rate = book.Rate,
                Genre = book.Genre,
                Quantity = book.Quantity,
                Price = book.Price,
                Url = book.Url,
                PublisherName = book.PublisherName,
                Description = book.Description
            };
            var _authorDtos = dbContext.BookAuthors.Where(ba => ba.BookId == bookId)
                .Select(ba => new AuthorDto()
                {
                    Name = ba.Author.Name,
                    PhoneNumber = ba.Author.PhoneNumber,
                    Email = ba.Author.Email,
                    Description = ba.Author.Description
                }).AsEnumerable();

            return new BookResponse<AuthorDto>()
            {
                bookDto = _bookDto,
                Dtos = _authorDtos
            };
        }
    }
}
