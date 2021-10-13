using BookShopBE.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Implementations
{
    public class FeedbackServices : IFeedbackServices
    {
        public Task GetFeedbackOfBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task RateStar(int customerId, int bookId, int starNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendFeedback(int customerId, int bookId, string message)
        {
            throw new NotImplementedException();
        }
    }
}
