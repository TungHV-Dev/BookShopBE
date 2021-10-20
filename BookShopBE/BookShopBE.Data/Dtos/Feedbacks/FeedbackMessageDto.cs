using System;

namespace BookShopBE.Data.Dtos.Feedbacks
{
    public class FeedbackMessageDto
    {
        public Guid CustomerId { get; set; }
        public int BookId { get; set; }
        public string Message { get; set; }
    }
}
