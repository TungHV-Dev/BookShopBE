using BookShopBE.Common.Dtos;
using BookShopBE.Common.Responses;
using BookShopBE.Data.Dtos.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface IOrderServices
    {
        Task<Result<IEnumerable<OrderResponse>>> GetAllOrder(BaseQuery query);
        Task<Result<OrderResponse>> GetOrderByOrderId(int orderId);
        Task<Result> CreateOrder(OrderDto order);
        Task<Result> EditOrder(EditOrderDto order);
        Task<Result> DeleteOrder(int orderId);
        Task ExportOrderInformationToExcel();
    }
}
