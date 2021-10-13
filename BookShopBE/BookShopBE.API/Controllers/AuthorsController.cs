//using BookShopBE.Common.Constants;
//using BookShopBE.Common.Dtos;
//using BookShopBE.Common.Paging;
//using BookShopBE.Data.Requests;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace BookShopBE.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthorsController : ControllerBase
//    {
//        #region Properties
//        private readonly IUnitOfWork unitOfWork;
//        #endregion

//        #region Ctor
//        public AuthorsController(IUnitOfWork unitOfWork)
//        {
//            this.unitOfWork = unitOfWork;
//        }
//        #endregion

//        #region Http Method
//        [HttpGet]
//        [Route("Get-All-Author")]
//        public async Task<IActionResult> GetAllAuthors()
//        {
//            var authors = await unitOfWork.Authors.GetAll();
//            if (authors == null)
//            {
//                return NotFound(ErrorDetails.NOT_FOUND);
//            }
//            return Ok(authors);
//        }

//        [HttpGet]
//        [Route("Get-Author-By-Id")]
//        public async Task<IActionResult> GetAuthorById(int authorId)
//        {
//            var author = await unitOfWork.Authors.GetById(authorId);
//            if (author == null)
//            {
//                return NotFound(ErrorDetails.ID_IS_NOT_EXIST);
//            }
//            return Ok(author);
//        }

//        [HttpGet]
//        [Route("Get-All-Paging")]
//        public async Task<IActionResult> GetAllPaging([FromQuery] PagingRequest request)
//        {
//            if (request == null)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_NULL);
//            }
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_INVALID);
//            }
//            var authors = await unitOfWork.Authors.GetAllPaging(request);
//            if (authors == null)
//            {
//                return NotFound(ErrorDetails.NOT_FOUND);
//            }
//            return Ok(authors);
//        }

//        [HttpGet]
//        [Route("Get-Books-Of-Author")]
//        public async Task<IActionResult> GetBooksOfAuthor(int authorId)
//        {
//            var books = await unitOfWork.Authors.GetBooksOfAuthor(authorId);
//            if (books == null)
//            {
//                return NotFound(ErrorDetails.ID_IS_NOT_EXIST);
//            }
//            return Ok(books);
//        }

//        [HttpPost]
//        [Route("Add-New-Author")]
//        public async Task<IActionResult> AddAuthor([FromForm] AuthorRequest<CreatedDto> request)
//        {
//            if (request == null)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_NULL);
//            }
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_INVALID);
//            }
//            await unitOfWork.Authors.Add(request);
//            await unitOfWork.CompleteAsync();
//            return Ok();
//        }

//        [HttpPut]
//        [Route("Update-An-Existing-Author")]
//        public async Task<IActionResult> UpdateAuthor(int authorId, [FromForm] AuthorRequest<ModifiedDto> request)
//        {
//            if (request == null)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_NULL);
//            }
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_INVALID);
//            }
//            await unitOfWork.Authors.Update(authorId, request);
//            await unitOfWork.CompleteAsync();
//            return Ok();
//        }

//        [HttpDelete]
//        [Route("Delete-Author")]
//        public async Task<IActionResult> DeleteAuthor(int authorId)
//        {
//            await unitOfWork.Authors.Delete(authorId);
//            await unitOfWork.CompleteAsync();
//            return Ok();
//        }
//        #endregion
//    }
//}
