using System;

namespace BookShopBE.Data.Dtos.Feedbacks
{
    public class RateStarDto
    {
        public Guid CustomerId { get; set; }
        public int BookId { get; set; }
        public int StarRate { get; set; }
    }
}
