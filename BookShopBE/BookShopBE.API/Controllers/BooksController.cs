//using BookShopBE.Common.Constants;
//using BookShopBE.Common.Dtos;
//using BookShopBE.Common.Paging;
//using BookShopBE.Data.Requests;
//using BookShopBE.Repository.UnitOfWorks;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace BookShopBE.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BooksController : ControllerBase
//    {
//        #region Properties
//        private readonly IUnitOfWork unitOfWork;
//        #endregion

//        #region Ctor
//        public BooksController(IUnitOfWork unitOfWork)
//        {
//            this.unitOfWork = unitOfWork;
//        }
//        #endregion

//        #region Htpp Method
//        [HttpGet]
//        [Route("Get-All-Books")]
//        public async Task<IActionResult> GetAllBooks()
//        {
//            var books = await unitOfWork.Books.GetAll();
//            if (books == null)
//            {
//                return NotFound(ErrorDetails.NOT_FOUND);
//            }
//            return Ok(books);
//        }

//        [HttpGet]
//        [Route("Get-Book-By-Id")]
//        public async Task<IActionResult> GetBookById(int bookId)
//        {
//            var book = await unitOfWork.Books.GetById(bookId);
//            if (book == null)
//            {
//                return NotFound(ErrorDetails.ID_IS_NOT_EXIST);
//            }
//            return Ok(book);
//        }

//        [HttpGet]
//        [Route("Get-All-Book-Paging")]
//        public async Task<IActionResult> GetAllPaging([FromQuery] PagingRequest request)
//        {
//            if(request == null)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_NULL);
//            }
//            if(!ModelState.IsValid)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_INVALID);
//            }
//            var books = await unitOfWork.Books.GetAllPaging(request);
//            if (books == null)
//            {
//                return NotFound(ErrorDetails.NOT_FOUND);
//            }
//            return Ok(books);
//        }

//        [HttpGet]
//        [Route("Get-Authors-Of-Book")]
//        public async Task<IActionResult> GetAuthorsOfBook(int bookId)
//        {
//            var authors = await unitOfWork.Books.GetAuthorsOfBook(bookId);
//            if(authors == null)
//            {
//                return NotFound(ErrorDetails.ID_IS_NOT_EXIST);
//            }
//            return Ok(authors);
//        }

//        [HttpGet]
//        [Route("Get-Stores-Has-Book")]
//        public async Task<IActionResult> GetStoresHasBook(int bookId)
//        {
//            var stores = await unitOfWork.Books.GetStoresOfBook(bookId);
//            if (stores == null)
//            {
//                return NotFound(ErrorDetails.ID_IS_NOT_EXIST);
//            }
//            return Ok(stores);
//        }

//        [HttpPost]
//        [Route("Add-New-Book")]
//        public async Task<IActionResult> AddBook([FromForm] BookRequest<CreatedDto> request)
//        {
//            if(request == null)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_NULL);
//            }
//            if(!ModelState.IsValid)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_INVALID);
//            }
//            await unitOfWork.Books.Add(request);
//            await unitOfWork.CompleteAsync();
//            return Ok();
//        }

//        [HttpPut]
//        [Route("Update-An-Existing-Book")]
//        public async Task<IActionResult> UpdateBook(int bookId, [FromForm] BookRequest<ModifiedDto> request)
//        {
//            if (request == null)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_NULL);
//            }
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_INVALID);
//            }
//            await unitOfWork.Books.Update(bookId, request);
//            await unitOfWork.CompleteAsync();
//            return Ok();
//        }

//        [HttpDelete]
//        [Route("Delete-An-Existing-Book")]
//        public async Task<IActionResult> DeleteBook(int bookId)
//        {
//            await unitOfWork.Books.Delete(bookId);
//            await unitOfWork.CompleteAsync();
//            return Ok();
//        }
//        #endregion
//    }
//}
