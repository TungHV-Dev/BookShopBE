using BookShopBE.Common.Repository;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Dtos.Carts;
using BookShopBE.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Implementations
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        private readonly BookShopDbContext dbContext;
        public CartRepository(BookShopDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task Add(CartDto cartDto)
        {
            var cart = new Cart
            {
                UserId = cartDto.UserId,
                BookId = cartDto.BookId,
                IsOrder = false,
                CreatedDate = DateTime.Now,
            };

            dbContext.Carts.Add(cart);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> GetCartId(CartDto cartDto)
        {
            int cartId = await dbContext.Carts.Where(cart => cart.UserId == cartDto.UserId && cart.BookId == cartDto.BookId)
                                              .Select(cart => cart.Id)
                                              .FirstOrDefaultAsync();

            return cartId;
        }

        public async Task<List<Cart>> GetAllCartOfUser(string userId)
        {
            var carts = await dbContext.Carts.Where(cart => cart.UserId == userId).ToListAsync();
            return carts;
        }

        public async Task DeleteRange(IEnumerable<Cart> cart)
        {
            dbContext.Carts.RemoveRange(cart);
            await dbContext.SaveChangesAsync();
        }
    }
}
