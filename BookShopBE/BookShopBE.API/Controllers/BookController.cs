using BookShopBE.Common.Constants;
using BookShopBE.Common.Dtos;
using BookShopBE.Common.Responses;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BookController : ControllerBase
    {
        #region Properties
        private readonly IBookServices _bookService;
        #endregion Properties

        #region Contructor
        public BookController(IBookServices bookService)
        {
            _bookService = bookService;
        }
        #endregion Contructor

        #region Public
        [HttpGet]
        [Route("Get-Book")]
        public async Task<ActionResult<Result<BookResponse>>> GetBook(int bookId)
        {
            var response = await _bookService.GetBook(bookId);
            if (response.Error != null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Get-All-Books")]
        public async Task<ActionResult<Result<IEnumerable<BookResponse>>>> GetAllBook([FromQuery] BaseQuery query)
        {
            if (query == null)
            {
                return BadRequest(Result<IEnumerable<BookResponse>>.Fail(new Error
                {
                    Code = HttpContext.Response.StatusCode,
                    Message = ErrorDetails.MODEL_IS_NULL
                }));
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(Result<IEnumerable<BookResponse>>.Fail(new Error
                {
                    Code = HttpContext.Response.StatusCode,
                    Message = ErrorDetails.MODEL_IS_INVALID
                }));
            }
            var response = await _bookService.GetAllBook(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("Search-Book")]
        public async Task<ActionResult<Result<IEnumerable<BookResponse>>>> Search([FromQuery] SearchBookRequest request)
        {
            if(request == null)
            {
                return BadRequest(Result<IEnumerable<BookResponse>>.Fail(new Error
                {
                    Code = HttpContext.Response.StatusCode,
                    Message = ErrorDetails.MODEL_IS_NULL
                }));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(Result<IEnumerable<BookResponse>>.Fail(new Error
                {
                    Code = HttpContext.Response.StatusCode,
                    Message = ErrorDetails.MODEL_IS_INVALID
                }));
            }
            var response = await _bookService.Search(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("Filter-Book")]
        public async Task<ActionResult<Result<IEnumerable<BookResponse>>>> Filter([FromQuery] FilterBookRequest request)
        {
            if (request == null)
            {
                return BadRequest(Result<IEnumerable<BookResponse>>.Fail(new Error
                {
                    Code = HttpContext.Response.StatusCode,
                    Message = ErrorDetails.MODEL_IS_NULL
                }));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(Result<IEnumerable<BookResponse>>.Fail(new Error
                {
                    Code = HttpContext.Response.StatusCode,
                    Message = ErrorDetails.MODEL_IS_INVALID
                }));
            }

            var response = await _bookService.Filter(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("Add-Book")]
        public async Task<ActionResult<Result>> AddBook([FromForm] AddBookRequest request)
        {
            if (request == null)
            {
                return BadRequest(new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = HttpContext.Response.StatusCode, Message = ErrorDetails.MODEL_IS_NULL }
                });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = HttpContext.Response.StatusCode, Message = ErrorDetails.MODEL_IS_NULL }
                });
            }

            var response = await _bookService.AddBook(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("Update-Book")]
        public async Task<ActionResult<Result>> Update([FromForm] UpdateBookRequest request)
        {
            if (request == null)
            {
                return BadRequest(new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = HttpContext.Response.StatusCode, Message = ErrorDetails.MODEL_IS_NULL }
                });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = HttpContext.Response.StatusCode, Message = ErrorDetails.MODEL_IS_NULL }
                });
            }

            var response = await _bookService.UpdateBook(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete-Book")]
        public async Task<ActionResult<Result>> Delete(int bookId)
        {
            var response = await _bookService.DeleteBook(bookId);
            if(!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        #endregion Public
    }
}
