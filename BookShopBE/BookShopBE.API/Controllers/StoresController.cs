//using BookShopBE.Common.Constants;
//using BookShopBE.Common.Dtos;
//using BookShopBE.Data.Requests;
//using BookShopBE.Repository.UnitOfWorks;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace BookShopBE.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StoresController : ControllerBase
//    {
//        #region Properties
//        private readonly IUnitOfWork unitOfWork;
//        #endregion

//        #region Ctor
//        public StoresController(IUnitOfWork unitOfWork)
//        {
//            this.unitOfWork = unitOfWork;
//        }
//        #endregion

//        #region Http Method
//        [HttpGet]
//        [Route("Get-All-Stores")]
//        public async Task<IActionResult> GetAllStores()
//        {
//            var stores = await unitOfWork.Stores.GetAll();
//            if (stores == null)
//            {
//                return NotFound(ErrorDetails.NOT_FOUND);
//            }
//            return Ok(stores);
//        }

//        [HttpGet]
//        [Route("Get-Store-By-Id")]
//        public async Task<IActionResult> GetStoreById(int storeId)
//        {
//            var store = await unitOfWork.Stores.GetById(storeId);
//            if (store == null)
//            {
//                return NotFound(ErrorDetails.ID_IS_NOT_EXIST);
//            }
//            return Ok(store);
//        }

//        [HttpGet]
//        [Route("Get-Books-Of-Store")]
//        public async Task<IActionResult> GetBooksOfStore(int storeId)
//        {
//            var book = await unitOfWork.Stores.GetBooksOfStore(storeId);
//            if (book == null)
//            {
//                return NotFound(ErrorDetails.ID_IS_NOT_EXIST);
//            }
//            return Ok(book);
//        }

//        [HttpPost]
//        [Route("Add-New-Store")]
//        public async Task<IActionResult> AddStore([FromForm] StoreRequest<CreatedDto> request)
//        {
//            if (request == null)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_NULL);
//            }
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_INVALID);
//            }
//            await unitOfWork.Stores.Add(request);
//            await unitOfWork.CompleteAsync();
//            return Ok();
//        }

//        [HttpPut]
//        [Route("Update-An-Existing-Store")]
//        public async Task<IActionResult> UpdateStore(int storeId, [FromForm] StoreRequest<ModifiedDto> request)
//        {
//            if (request == null)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_NULL);
//            }
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ErrorDetails.MODEL_IS_INVALID);
//            }
//            await unitOfWork.Stores.Update(storeId, request);
//            await unitOfWork.CompleteAsync();
//            return Ok();
//        }

//        [HttpDelete]
//        [Route("Delete-Store")]
//        public async Task<IActionResult> DeleteStore(int storeId)
//        {
//            await unitOfWork.Stores.Delete(storeId);
//            await unitOfWork.CompleteAsync();
//            return Ok();
//        }
//        #endregion
//    }
//}
