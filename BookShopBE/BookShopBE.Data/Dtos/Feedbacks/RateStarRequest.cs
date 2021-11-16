namespace BookShopBE.Data.Dtos.Feedbacks
{
    public class RateStarRequest
    {
        public int BookId { get; set; }
        public int StarRate { get; set; }
    }

    public class RateStarDto : RateStarRequest
    {
        public string CustomerId { get; set; }
    }
}
