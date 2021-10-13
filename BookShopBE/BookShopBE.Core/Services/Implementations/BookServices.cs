using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Implementations
{
    public class BookServices : IBookServices
    {
        private IUnitOfWork _unitOfWork;

        public BookServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<BookResponse>> GetAllBook()
        {
            throw new NotImplementedException();
        }

        public Task<BookResponse> GetBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookResponse>> Search(string content)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookResponse>> Filter(string genre, int minPrice, int maxPrice)
        {
            throw new NotImplementedException();
        }
    }
}
