using BookShopBE.Common.Responses;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookShopBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class CartController : ControllerBase
    {
        #region Properties
        private readonly ICartServices _cartServices;
        #endregion

        #region Contructor
        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        #endregion

        #region Public
        [HttpGet]
        [Route("Get-Carts-Of-Customer")]
        public async Task<ActionResult<Result<CartResponse>>> GetCartsOfCustomer()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _cartServices.GetCartsOfUser(userId);
            if(response.IsSuccess == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Add-Book-To-Cart")]
        public async Task<ActionResult<Result>> AddBookToCart(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartDto = new CartDto { UserId = userId, BookId = bookId };

            var response = await _cartServices.AddBookToCart(cartDto);
            if(response.IsSuccess == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete-Book-From-Cart")]
        public async Task<ActionResult<Result>> DeleteBookFromCart(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartDto = new CartDto { UserId = userId, BookId = bookId };

            var response = await _cartServices.DeleteBookFromCart(cartDto);
            if (response.IsSuccess == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete-Cart-Of-Customer")]
        public async Task<ActionResult<Result>> DeleteCartsOfUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _cartServices.DeleteCartsOfUser(userId);
            if (response.IsSuccess == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        #endregion
    }
}
