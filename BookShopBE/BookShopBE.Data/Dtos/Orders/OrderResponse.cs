using System;

namespace BookShopBE.Data.Dtos.Orders
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string BookName { get; set; }
        public int OrderNumber { get; set; }
        public double TotalMoney { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
