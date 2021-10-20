using BookShopBE.Common.Responses;
using BookShopBE.Data.Dtos.Feedbacks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface IFeedbackServices
    {
        Task<Result<IEnumerable<FeedbackResponse>>> GetFeedbackOfBook(int bookId);
        Task<Result> SendFeedbackMessage(FeedbackMessageDto dto);
        Task<Result> EditFeedbackMessage(int feedbackId, string message);
        Task<Result> Delete(int feedbackId);
        Task<Result> RateStar(RateStarDto dto);
    }
}
