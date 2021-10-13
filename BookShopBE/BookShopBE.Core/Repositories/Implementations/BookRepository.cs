using BookShopBE.Common.Dtos;
using BookShopBE.Common.Repository;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Dtos;
using BookShopBE.Data.Models;
using BookShopBE.Data.Requests;
using BookShopBE.Data.Responses;
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

        public async Task Add(BookRequest<CreatedDto> request)
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
                CreatedDate = request.bookDto.Dto.CreatedDate,
                CreatedBy = request.bookDto.Dto.CreatedBy
            };
            dbContext.Books.Add(book);

            if (request.IsAddOrUpdateAuthors)
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

            if (request.IsAddOrUpdateStores)
            {
                foreach (int storeId in request.StoreIds)
                {
                    var book_store = new BookStore()
                    {
                        BookId = book.Id,
                        StoreId = storeId
                    };
                    dbContext.BookStores.Add(book_store);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task Update(int bookId, BookRequest<ModifiedDto> request)
        {
            var book = await dbContext.Books.FindAsync(bookId);
            book.Name = request.bookDto.Name;
            book.Description = request.bookDto.Description;
            book.Rate = request.bookDto.Rate;
            book.Genre = request.bookDto.Genre;
            book.Quantity = request.bookDto.Quantity;
            book.Price = request.bookDto.Price;
            book.Url = request.bookDto.Url;
            book.PublisherName = request.bookDto.PublisherName;
            book.ModifiedDate = request.bookDto.Dto.ModifiedDate;
            book.ModifiedBy = request.bookDto.Dto.ModifiedBy;

            if (request.IsAddOrUpdateAuthors)
            {
                var ListBookAuthor = await dbContext.BookAuthors.Where(x => x.BookId == bookId).ToListAsync();
                dbContext.BookAuthors.RemoveRange(ListBookAuthor);

                foreach (int id in request.AuthorIds)
                {
                    var book_author = new BookAuthor()
                    {
                        BookId = bookId,
                        AuthorId = id
                    };
                    dbContext.BookAuthors.Add(book_author);
                }
            }

            if (request.IsAddOrUpdateStores)
            {
                var ListBookStore = await dbContext.BookStores.Where(x => x.BookId == bookId).ToListAsync();
                dbContext.BookStores.RemoveRange(ListBookStore);

                foreach (int id in request.StoreIds)
                {
                    var book_store = new BookStore()
                    {
                        BookId = bookId,
                        StoreId = id
                    };
                    dbContext.BookStores.Add(book_store);
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
            var _authorDtos = await dbContext.BookAuthors.Where(ba => ba.BookId == bookId)
                .Select(ba => new AuthorDto()
                {
                    Name = ba.Author.Name,
                    PhoneNumber = ba.Author.PhoneNumber,
                    Email = ba.Author.Email,
                    Description = ba.Author.Description
                }).ToListAsync();

            return new BookResponse<AuthorDto>()
            {
                bookDto = _bookDto,
                Dtos = _authorDtos
            };
        }

        public async Task<BookResponse<StoreDto>> GetStoresOfBook(int bookId)
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
            var _storeDtos = await dbContext.BookStores.Where(bs => bs.BookId == bookId)
                .Select(bs => new StoreDto()
                {
                    Name = bs.Store.Name,
                    Address = bs.Store.Address,
                    PhoneNumber = bs.Store.PhoneNumber,
                    Description = bs.Store.Description
                }).ToListAsync();

            return new BookResponse<StoreDto>()
            {
                bookDto = _bookDto,
                Dtos = _storeDtos
            };
        }
    }
}
