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
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        private readonly BookShopDbContext dbContext;
        public AuthorRepository(BookShopDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task Add(AddAuthorRequest request)
        {
            var author = new Author()
            {
                Name = request.authorDto.Name,
                PhoneNumber = request.authorDto.PhoneNumber,
                Email = request.authorDto.Email,
                Description = request.authorDto.Description,
                CreatedDate = request.CreatedDate,
                CreatedBy = request.CreatedBy
            };
            dbContext.Authors.Add(author);

            if(request.IsAddOrUpdateBooks)
            {
                foreach(int bookId in request.bookIds)
                {
                    var book_author = new BookAuthor()
                    {
                        BookId = bookId,
                        AuthorId = author.Id
                    };
                    dbContext.BookAuthors.Add(book_author);
                }
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(UpdateAuthorRequest request)
        {
            var author = await dbContext.Authors.FindAsync(request.authorId);
            author.Name = request.authorDto.Name;
            author.PhoneNumber = request.authorDto.PhoneNumber;
            author.Email = request.authorDto.Email;
            author.Description = request.authorDto.Description;
            author.ModifiedDate = request.ModifiedDate;
            author.ModifiedBy = request.ModifiedBy;

            if(request.IsAddOrUpdateBooks)
            {
                var ListBookAuthor = await dbContext.BookAuthors.Where(x => x.AuthorId == author.Id).ToListAsync();
                dbContext.BookAuthors.RemoveRange(ListBookAuthor);

                foreach (int id in request.bookIds)
                {
                    var book_author = new BookAuthor()
                    {
                        BookId = id,
                        AuthorId = author.Id
                    };
                    dbContext.BookAuthors.Add(book_author);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<AuthorResponse<BookDto>> GetBooksOfAuthor(int authorId)
        {
            var author = await dbContext.Authors.FindAsync(authorId);
            var _authorDto = new AuthorDto()
            {
                Name = author.Name,
                PhoneNumber = author.PhoneNumber,
                Email = author.Email,
                Description = author.Description
            };

            var _bookDtos = await dbContext.BookAuthors.Where(a => a.AuthorId == authorId)
                .Select(ba => new BookDto()
                {
                    Name = ba.Book.Name,
                    Rate = ba.Book.Rate,
                    Genre = ba.Book.Genre,
                    Quantity = ba.Book.Quantity,
                    Price = ba.Book.Price,
                    Url = ba.Book.Url,
                    PublisherName = ba.Book.PublisherName,
                    Description = ba.Book.Description
                }).ToListAsync();

            return new AuthorResponse<BookDto>()
            {
                authorDto = _authorDto,
                Dtos = _bookDtos
            };
        }
    }
}
