
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Domain.Interface
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart?> GetShoppingCartAsync(string userName);
        Task CreateShoppingCartAsync(ShoppingCart shoppingCart);
        Task<int> UpdateShoppingCartItemAsync(string title,ShoppingCartItem shoppingCartItem);
        Task DeleteShoppingCartAsync(string userName);
        Task AddGameToCartAsync(string userName, int gameId);
        Task RemoveItemFromCartAsync(string userName, int gameId);
    }
}
