using BookShopBE.Common.Repository;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Implementations
{
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        private readonly BookShopDbContext dbContext;
        public FeedbackRepository(BookShopDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task<List<Feedback>> GetFeedbacksByBookId(int bookId)
        {
            var response = await dbContext.Feedbacks.Where(fb => fb.BookId == bookId).ToListAsync();
            return response;
        }

        public async Task Add(Feedback feedback)
        {
            dbContext.Feedbacks.Add(feedback);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Feedback> GetFeedbackToRateStar(Guid customerId, int bookId)
        {
            var response = await dbContext.Feedbacks.Where(fb => fb.CustomerId == customerId && fb.BookId == bookId).FirstOrDefaultAsync();
            return response;
        }
    }
}
