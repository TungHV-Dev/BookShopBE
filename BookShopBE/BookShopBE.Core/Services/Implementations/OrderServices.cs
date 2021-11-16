using AutoMapper;
using BookShopBE.Common.Constants;
using BookShopBE.Common.Dtos;
using BookShopBE.Common.Paging;
using BookShopBE.Common.Responses;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Orders;
using BookShopBE.Data.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Implementations
{
    public class OrderServices : IOrderServices
    {
        #region Properties
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PagingDefaultOption _pagingDefaultOption;
        #endregion Properties

        #region Contructor
        public OrderServices(IUnitOfWork unitOfWork, IMapper mapper, IOptions<PagingDefaultOption> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pagingDefaultOption = options.Value;
        }
        #endregion Contructor

        #region Public
        public async Task<Result<IEnumerable<OrderResponse>>> GetAllOrder(BaseQuery query)
        {
            int pageNumber = query.PageNumber == 0 ? _pagingDefaultOption.DefaultPageNumber : query.PageNumber;
            int pageSize = query.PageSize == 0 ? _pagingDefaultOption.DefaultPageSize : query.PageSize;

            var orders = await _unitOfWork.Orders.GetAll();
            if(orders == null)
            {
                return Result<IEnumerable<OrderResponse>>.Fail(new Error
                {
                    Code = 404,
                    Message = ErrorDetails.ORDER_LIST_IS_EMPTY
                });
            }
            orders = PaginatedList<Order>.Create(orders.AsQueryable(), pageNumber, pageSize);

            var response = _mapper.Map<IEnumerable<OrderResponse>>(orders);
            return Result<IEnumerable<OrderResponse>>.Success(response.AsEnumerable());
        }

        public async Task<Result<OrderResponse>> GetOrderByOrderId(int orderId)
        {
            var order = await _unitOfWork.Orders.GetById(orderId);
            if(order == null)
            {
                return Result<OrderResponse>.Fail(new Error
                {
                    Code = 404,
                    Message = ErrorDetails.ORDER_ID_DOES_NOT_EXIST
                });
            }

            var response = _mapper.Map<OrderResponse>(order);
            return Result<OrderResponse>.Success(response);
        }

        //public async Task<Result<OrderResponse>> GetOrderByCustomerId(string customerId)
        //{

        //}

        public async Task<Result> CreateOrder(OrderDto order)
        {
            var user = await _unitOfWork.Users.GetById(order.CustomerId);
            if(user == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.CUSTOMER_DOES_NOT_EXIST }
                };
            }

            var book = await _unitOfWork.Books.GetById(order.BookId);
            if(book.Quantity < order.OrderNumber)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 400, Message = ErrorDetails.BOOK_QUANTITY_IS_NOT_ENOUGH }
                };
            }

            var _order = new Order
            {
                CustomerId = order.CustomerId,
                BookId = order.BookId,
                OrderNumber = order.OrderNumber,
                DeliveryAddress = order.DeliveryAddress,
                CreatedDate = DateTime.Now,
                TotalMoney = book.Price * order.OrderNumber,
                IsSuccess = true
            };

            var customer = _mapper.Map<CustomerHasOrder>(user);

            await _unitOfWork.Customers.Add(customer);
            await _unitOfWork.Orders.Add(_order);
            await _unitOfWork.CompleteAsync();
            // Todo: add customer
            return new Result
            {
                IsSuccess = true,
                Error = null
            };
        }

        public async Task<Result> EditOrder(EditOrderDto order)
        {
            var user = await _unitOfWork.Users.GetById(order.CustomerId);
            if (user == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.CUSTOMER_DOES_NOT_EXIST }
                };
            }

            var _order = await _unitOfWork.Orders.GetById(order.OrderId);
            if(_order == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.ORDER_ID_DOES_NOT_EXIST }
                };
            }

            var book = await _unitOfWork.Books.GetById(order.BookId);
            if (book.Quantity < order.OrderNumber)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 400, Message = ErrorDetails.BOOK_QUANTITY_IS_NOT_ENOUGH }
                };
            }

            await _unitOfWork.Orders.Update(order);
            await _unitOfWork.CompleteAsync();
            return new Result { IsSuccess = true, Error = null };
        }

        public async Task<Result> DeleteOrder(int orderId)
        {
            var order = await _unitOfWork.Orders.GetById(orderId);
            if(order == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.ORDER_ID_DOES_NOT_EXIST }
                };
            }

            await _unitOfWork.Orders.Delete(orderId);
            await _unitOfWork.CompleteAsync();

            return new Result
            {
                IsSuccess = true,
                Error = null
            };
        }

        public Task ExportOrderInformationToExcel()
        {
            throw new NotImplementedException();
        }
        #endregion Public
    }
}
