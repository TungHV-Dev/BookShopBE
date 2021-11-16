using System;

namespace BookShopBE.Data.Dtos.Feedbacks
{
    public class FeedbackResponse
    {
        public int FeedbackId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int StarRate { get; set; }
        public string Message { get; set; }
    }
}
