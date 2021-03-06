using AutoMapper;
using BookShopBE.Common.Constants;
using BookShopBE.Common.Responses;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Carts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Implementations
{
    public class CartServices : ICartServices
    {
        #region Properties
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public CartServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Public
        public async Task<Result<CartResponse>> GetCartsOfUser(string userId)
        {
            var carts = await _unitOfWork.Carts.GetAllCartOfUser(userId);
            if (carts == null || carts.Count == 0)
            {
                return Result<CartResponse>.Fail(new Error
                {
                    Code = 404,
                    Message = ErrorDetails.CUSTOMER_CART_IS_EMPTY
                });
            }

            var response = new CartResponse
            {
                UserName = carts[0].User.UserName,
                UserEmail = carts[0].User.Email
            };
            response.BookInformations = _mapper.Map<IEnumerable<BookInCartDto>>(carts).ToList();

            return Result<CartResponse>.Success(response);
        }

        public async Task<Result> AddBookToCart(CartDto cartDto)
        {
            var customer = await _unitOfWork.Users.GetById(cartDto.UserId);
            if (customer == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.USER_ID_DOES_NOT_EXIST }
                };
            }

            await _unitOfWork.Carts.Add(cartDto);
            await _unitOfWork.CompleteAsync();
            return new Result { IsSuccess = true, Error = null };
        }

        public async Task<Result> DeleteBookFromCart(CartDto cartDto)
        {
            int cartId = await _unitOfWork.Carts.GetCartId(cartDto);
            var cart = await _unitOfWork.Carts.GetById(cartId);
            if (cart == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.CART_ID_DOES_NOT_EXIST }
                };
            }

            await _unitOfWork.Carts.Delete(cartId);
            await _unitOfWork.CompleteAsync();
            return new Result { IsSuccess = true, Error = null };
        }

        public async Task<Result> DeleteCartsOfUser(string userId)
        {
            var user = await _unitOfWork.Users.GetById(userId);
            if (user == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.USER_ID_DOES_NOT_EXIST }
                };
            }

            var carts = await _unitOfWork.Carts.GetAllCartOfUser(userId);
            if (carts == null || carts.Count == 0)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.CUSTOMER_CART_IS_EMPTY }
                };
            }

            await _unitOfWork.Carts.DeleteRange(carts);
            await _unitOfWork.CompleteAsync();
            return new Result { IsSuccess = true, Error = null };
        }
        #endregion Public
    }
}
