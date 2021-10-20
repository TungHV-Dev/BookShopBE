using AutoMapper;
using BookShopBE.Common.Constants;
using BookShopBE.Common.Dtos;
using BookShopBE.Common.Paging;
using BookShopBE.Common.Responses;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Books;
using BookShopBE.Data.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Implementations
{
    public class BookServices : IBookServices
    {
        #region Properties
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PagingDefaultOption _pagingDefaultOption;
        #endregion

        #region Contructor
        public BookServices(IUnitOfWork unitOfWork, IMapper mapper, IOptions<PagingDefaultOption> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pagingDefaultOption = options.Value;
        }
        #endregion

        #region Public
        public async Task<Result<IEnumerable<BookResponse>>> GetAllBook(BaseQuery query)
        {
            int pageNumber = query.PageNumber == 0 ? _pagingDefaultOption.DefaultPageNumber : query.PageNumber;
            int pageSize = query.PageSize == 0 ? _pagingDefaultOption.DefaultPageSize : query.PageSize;

            var books = await _unitOfWork.Books.GetAll();
            books = PaginatedList<Book>.Create(books.AsQueryable(), pageNumber, pageSize);

            var responses = new List<BookResponse>();
            foreach(var book in books)
            {
                var bookResponse = _mapper.Map<BookResponse>(book);
                bookResponse.AuthorNames = GetAuthorNamesOfBook(book.Id);
                responses.Add(bookResponse);
            }

            return Result<IEnumerable<BookResponse>>.Success(responses.AsEnumerable());
        }

        public async Task<Result<BookResponse>> GetBook(int bookId)
        {
            var book = await _unitOfWork.Books.GetById(bookId);
            if (book == null)
            {
                return Result<BookResponse>.Fail(new Error { Code = 404, Message = ErrorDetails.BOOK_ID_DOES_NOT_EXIST });
            }

            var response = _mapper.Map<BookResponse>(book);
            response.AuthorNames = GetAuthorNamesOfBook(bookId);

            return Result<BookResponse>.Success(response);
        }

        public async Task<Result<IEnumerable<BookResponse>>> Search(SearchBookRequest request)
        {
            int pageNumber = request.PageNumber == 0 ? _pagingDefaultOption.DefaultPageNumber : request.PageNumber;
            int pageSize = request.PageSize == 0 ? _pagingDefaultOption.DefaultPageSize : request.PageSize;

            var books = await _unitOfWork.Books.GetAll();
            if(!String.IsNullOrEmpty(request.SearchingContent))
            {
                books = books.Where(book => book.Name.Contains(request.SearchingContent, StringComparison.CurrentCultureIgnoreCase)
                                         || book.Genre.Contains(request.SearchingContent, StringComparison.CurrentCultureIgnoreCase)
                                         || CheckAuthorNamesOfBook(book.Id, request.SearchingContent));
            }

            books = PaginatedList<Book>.Create(books.AsQueryable(), pageNumber, pageSize);

            var responses = new List<BookResponse>();
            foreach (var book in books)
            {
                var bookResponse = _mapper.Map<BookResponse>(book);
                bookResponse.AuthorNames = GetAuthorNamesOfBook(book.Id);
                responses.Add(bookResponse);
            }

            return Result<IEnumerable<BookResponse>>.Success(responses.AsEnumerable());
        }

        public async Task<Result<IEnumerable<BookResponse>>> Filter(FilterBookRequest request)
        {
            int pageNumber = request.PageNumber == 0 ? _pagingDefaultOption.DefaultPageNumber : request.PageNumber;
            int pageSize = request.PageSize == 0 ? _pagingDefaultOption.DefaultPageSize : request.PageSize;

            var books = await _unitOfWork.Books.GetAll();

            if(!String.IsNullOrEmpty(request.Genre))
            {
                books = books.Where(book => book.Genre.Contains(request.Genre, StringComparison.CurrentCultureIgnoreCase));
            }

            if(request.MinPrice != null)
            {
                books = books.Where(book => book.Price >= request.MinPrice);
            }

            if(request.MaxPrice != null)
            {
                books = books.Where(book => book.Price <= request.MaxPrice);
            }

            books = PaginatedList<Book>.Create(books.AsQueryable(), pageNumber, pageSize);
            var responses = new List<BookResponse>();
            foreach (var book in books)
            {
                var bookResponse = _mapper.Map<BookResponse>(book);
                bookResponse.AuthorNames = GetAuthorNamesOfBook(book.Id);
                responses.Add(bookResponse);
            }

            return Result<IEnumerable<BookResponse>>.Success(responses.AsEnumerable());
        }

        public async Task<Result> AddBook(AddBookRequest request)
        {
            await _unitOfWork.Books.Add(request);
            await _unitOfWork.CompleteAsync();
            return new Result { IsSuccess = true, Error = null };
        }

        public async Task<Result> UpdateBook(UpdateBookRequest request)
        {
            var book = await _unitOfWork.Books.GetById(request.bookId);
            if(book == null)
            {
                return new Result { IsSuccess = false, Error = new Error { Code = 404, Message = ErrorDetails.BOOK_ID_DOES_NOT_EXIST } };
            }

            await _unitOfWork.Books.Update(request);
            await _unitOfWork.CompleteAsync();
            return new Result { IsSuccess = true, Error = null };
        }

        public async Task<Result> DeleteBook(int bookId)
        {
            var book = await _unitOfWork.Books.GetById(bookId);
            if (book == null)
            {
                return new Result { IsSuccess = false, Error = new Error { Code = 404, Message = ErrorDetails.BOOK_ID_DOES_NOT_EXIST } };
            }
            await _unitOfWork.Books.Delete(bookId);
            await _unitOfWork.CompleteAsync();
            return new Result { IsSuccess = true, Error = null };
        }

        #endregion Public

        #region Private
        private bool CheckAuthorNamesOfBook(int bookId, string searchingContent)
        {
            var authors = _unitOfWork.Books.GetAuthorsOfBook(bookId).Result;
            var authorNames = authors.Dtos.Select(dto => dto.Name);
            foreach(var name in authorNames)
            {
                if(name.Contains(searchingContent, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private IEnumerable<string> GetAuthorNamesOfBook(int bookId)
        {
            var response = _unitOfWork.Books.GetAuthorsOfBook(bookId).Result;
            var result = new List<string>();
            foreach(var dto in response.Dtos)
            {
                result.Add(dto.Name);
            }
            return result.AsEnumerable();
        }

        #endregion Private
    }
}
