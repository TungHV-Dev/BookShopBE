using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Implementations
{
    public class OrderServices : IOrderServices
    {
        private IUnitOfWork _unitOfWork;

        public OrderServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> CreateOrder()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrder()
        {
            throw new NotImplementedException();
        }

        public Task ExportOrderInformationToExcel()
        {
            throw new NotImplementedException();
        }

        public Task GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public Task GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
