using AutoMapper;
using BookShopBE.Common.Constants;
using BookShopBE.Common.Dtos;
using BookShopBE.Common.Paging;
using BookShopBE.Common.Responses;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Users;
using BookShopBE.Data.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Implementations
{
    public class UserServices : IUserServices
    {
        #region Properties
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PagingDefaultOption _pagingDefaultOption;
        #endregion Properties

        #region Contructor
        public UserServices(IUnitOfWork unitOfWork, IMapper mapper, IOptions<PagingDefaultOption> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pagingDefaultOption = options.Value;
        }
        #endregion

        #region Public
        public async Task<Result<IEnumerable<UserDto>>> GetAllUsers(BaseQuery query)
        {
            int pageNumber = query.PageNumber == 0 ? _pagingDefaultOption.DefaultPageNumber : query.PageNumber;
            int pageSize = query.PageSize == 0 ? _pagingDefaultOption.DefaultPageSize : query.PageSize;

            var users = await _unitOfWork.Users.GetAll();
            users = PaginatedList<User>.Create(users.AsQueryable(), pageNumber, pageSize);

            var responses = _mapper.Map<IEnumerable<UserDto>>(users);
            return Result<IEnumerable<UserDto>>.Success(responses);
        }

        public async Task<Result<UserDto>> GetUser(string userId)
        {
            var user = await _unitOfWork.Users.GetById(userId);
            var response = _mapper.Map<UserDto>(user);
            return Result<UserDto>.Success(response);
        }

        public async Task<Result> UpdateUser(UserDto userDto)
        {
            if(userDto == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 400, Message = ErrorDetails.MODEL_IS_NULL }
                };
            }
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.Users.UpdateUser(user);
            return new Result { IsSuccess = true, Error = null };
        }

        public async Task<Result> DeleteUser(string userId)
        {
            var response = await _unitOfWork.Users.Delete(userId);
            if(!response)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.USER_ID_DOES_NOT_EXIST }
                };
            }
            return new Result { IsSuccess = true, Error = null };
        }

        #endregion Public
    }
}
