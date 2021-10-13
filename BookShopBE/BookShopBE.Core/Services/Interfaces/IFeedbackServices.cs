using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface IFeedbackServices
    {
        Task<bool> SendFeedback(int customerId, int bookId, string message);
        Task RateStar(int customerId, int bookId, int starNumber);
        Task GetFeedbackOfBook(int bookId);
    }
}
