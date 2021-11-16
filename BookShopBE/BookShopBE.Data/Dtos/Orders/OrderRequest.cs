namespace BookShopBE.Data.Dtos.Orders
{
    public class OrderRequest
    {
        public int BookId { get; set; }
        public int OrderNumber { get; set; }
        public string DeliveryAddress { get; set; }
    }

    public class OrderDto : OrderRequest
    {
        public string CustomerId { get; set; }
    }

    public class EditOrderRequest : OrderRequest
    {
        public int OrderId { get; set; }
    }

    public class EditOrderDto : EditOrderRequest
    {
        public string CustomerId { get; set; }
    }
}
