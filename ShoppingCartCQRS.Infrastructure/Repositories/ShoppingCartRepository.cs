using Microsoft.EntityFrameworkCore;
using ShoppingCartCQRS.Domain.Interface;
using ShoppingCartCQRS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingCartDbContext _context;
        public ShoppingCartRepository(ShoppingCartDbContext shoppingCartDbContext) {
            _context = shoppingCartDbContext;
        }

        public Task AddGameToCartAsync(string userName, int gameId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            await _context.ShoppingCarts.AddAsync(shoppingCart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShoppingCartAsync(string userName)
        {
             await _context.ShoppingCarts.Where(x=>x.UserName.Equals(userName)).ExecuteDeleteAsync();
        }

        public async Task<ShoppingCart?> GetShoppingCartAsync(string userName)
        {
            return await _context.ShoppingCarts
            .Include(cart => cart.Items) 
            .FirstOrDefaultAsync(cart => cart.UserName == userName);
        }

        public Task RemoveItemFromCartAsync(string userName, int gameId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateShoppingCartItemAsync(string title, ShoppingCartItem shoppingCartItem)
        {
            return await _context.ShoppingCartItems.Where(x => x.GameTitle.Equals(title)).ExecuteUpdateAsync(update => update
            .SetProperty(x => x.GameId, shoppingCartItem.GameId)
            .SetProperty(x => x.GameTitle, shoppingCartItem.GameTitle)
            .SetProperty(x => x.Price, shoppingCartItem.Price));
        }
    }
}
