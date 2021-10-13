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
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        private readonly BookShopDbContext dbContext;
        public StoreRepository(BookShopDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task Add(StoreRequest<CreatedDto> request)
        {
            var store = new Store()
            {
                Name = request.storeDto.Name,
                Address = request.storeDto.Address,
                PhoneNumber = request.storeDto.PhoneNumber,
                Description = request.storeDto.Description,
                CreatedDate = request.storeDto.Dto.CreatedDate,
                CreatedBy = request.storeDto.Dto.CreatedBy
            };
            dbContext.Stores.Add(store);

            if (request.IsAddOrUpdateBooks)
            {
                foreach (int id in request.bookIds)
                {
                    var bookStore = new BookStore()
                    {
                        BookId = id,
                        StoreId = store.Id
                    };
                    dbContext.BookStores.Add(bookStore);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task Update(int storeId, StoreRequest<ModifiedDto> request)
        {
            var store = await dbContext.Stores.FindAsync(storeId);
            store.Name = request.storeDto.Name;
            store.Address = request.storeDto.Address;
            store.PhoneNumber = request.storeDto.PhoneNumber;
            store.Description = request.storeDto.Description;
            store.ModifiedDate = request.storeDto.Dto.ModifiedDate;
            store.ModifiedBy = request.storeDto.Dto.ModifiedBy;

            if (request.IsAddOrUpdateBooks)
            {
                var ListBookStore = await dbContext.BookStores.Where(s => s.StoreId == storeId).ToListAsync();
                dbContext.BookStores.RemoveRange(ListBookStore);

                foreach (int id in request.bookIds)
                {
                    var book_store = new BookStore()
                    {
                        StoreId = storeId,
                        BookId = id
                    };
                    dbContext.BookStores.Add(book_store);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<StoreResponse<BookDto>> GetBooksOfStore(int storeId)
        {
            var store = await dbContext.Stores.FindAsync(storeId);
            var _storeDto = new StoreDto()
            {
                Name = store.Name,
                PhoneNumber = store.PhoneNumber,
                Address = store.Address,
                Description = store.Description
            };

            var _bookDtos = await dbContext.BookStores.Where(bs => bs.StoreId == storeId)
                .Select(bs => new BookDto()
                {
                    Name = bs.Book.Name,
                    Rate = bs.Book.Rate,
                    Genre = bs.Book.Genre,
                    Quantity = bs.Book.Quantity,
                    Price = bs.Book.Price,
                    Url = bs.Book.Url,
                    PublisherName = bs.Book.PublisherName,
                    Description = bs.Book.Description
                }).ToListAsync();

            return new StoreResponse<BookDto>()
            {
                storeDto = _storeDto,
                Dtos = _bookDtos
            };
        }
    }
}
