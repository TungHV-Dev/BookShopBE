using System.Collections.Generic;

namespace BookShopBE.Data.Dtos.Carts
{
    public class CartResponse
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<BookInCartDto> BookInformations { get; set; }
    }
}
