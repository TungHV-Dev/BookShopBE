using System.Collections.Generic;

namespace BookShopBE.Data.Dtos.Carts
{
    public class CartResponse
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public List<BookInCartDto> BookInformations { get; set; }
    }
}
