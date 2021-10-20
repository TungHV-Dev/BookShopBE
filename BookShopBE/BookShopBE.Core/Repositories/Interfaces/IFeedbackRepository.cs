using BookShopBE.Common.Repository;
using BookShopBE.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Task Add(Feedback feedback);
        Task<List<Feedback>> GetFeedbacksByBookId(int bookId);
        Task<Feedback> GetFeedbackToRateStar(Guid customerId, int bookId);
    }
}
