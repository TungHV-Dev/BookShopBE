namespace BookShopBE.Data.Dtos.Feedbacks
{
    public class FeedbackRequest
    {
        public int BookId { get; set; }
        public string Message { get; set; }
    }

    public class FeedbackDto : FeedbackRequest
    {
        public string CustomerId { get; set; }
    }
}
