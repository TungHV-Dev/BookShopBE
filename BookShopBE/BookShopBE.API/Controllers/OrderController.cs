using BookShopBE.Common.Constants;
using BookShopBE.Common.Dtos;
using BookShopBE.Common.Responses;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookShopBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrderController : ControllerBase
    {
        #region Properties
        private readonly IOrderServices _orderServices;
        #endregion Properties

        #region Contructor
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        #endregion

        #region Public
        [HttpGet]
        [Route("Get-All-Orders")]
        [Authorize(Roles = RoleDetails.ADMINISTRATOR)]
        public async Task<ActionResult<Result<IEnumerable<OrderResponse>>>> GetAllOrder([FromQuery] BaseQuery query)
        {
            var response = await _orderServices.GetAllOrder(query);
            if(!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Get-Order")]
        [Authorize(Roles = RoleDetails.ADMINISTRATOR)]
        public async Task<ActionResult<Result<OrderResponse>>> GetOrder(int orderId)
        {
            var response = await _orderServices.GetOrderByOrderId(orderId);
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Create-Order")]
        public async Task<ActionResult<Result>> CreateOrder([FromForm] OrderRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = new OrderDto
            {
                CustomerId = userId,
                BookId = request.BookId,
                OrderNumber = request.OrderNumber,
                DeliveryAddress = request.DeliveryAddress
            };

            var response = await _orderServices.CreateOrder(order);
            if(response.Error != null)
            {
                if(response.Error.Code == 404)
                {
                    return NotFound(response);
                }
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Edit-Order")]
        public async Task<ActionResult<Result>> EditOrder(EditOrderRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = new EditOrderDto
            {
                BookId = request.BookId,
                CustomerId = userId,
                OrderId = request.OrderId,
                OrderNumber = request.OrderNumber,
                DeliveryAddress = request.DeliveryAddress
            };

            var response = await _orderServices.EditOrder(dto);
            if(!response.IsSuccess)
            {
                switch(response.Error.Code)
                {
                    case 404:
                        return NotFound(response);
                    case 400:
                        return BadRequest(response);
                }
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete-Order")]
        [Authorize(Roles = RoleDetails.ADMINISTRATOR)]
        public async Task<ActionResult<Result>> DeleteOrder(int orderId)
        {
            var response = await _orderServices.DeleteOrder(orderId);
            if(!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        #endregion
    }
}
