using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface IOrderServices
    {
        Task<bool> CreateOrder();
        Task<bool> DeleteOrder();
        Task GetOrder(int orderId);
        Task GetAllOrder();
        Task ExportOrderInformationToExcel();
    }
}
