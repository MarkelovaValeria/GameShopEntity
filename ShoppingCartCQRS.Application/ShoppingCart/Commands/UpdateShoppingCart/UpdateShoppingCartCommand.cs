using MediatR;
using ShoppingCartCQRS.Application.ShoppingCart.Queries.GetShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Application.ShoppingCart.Commands.UpdateShoppingCart
{
    public class UpdateShoppingCartCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }
        public string TitleUpdate { get; set; }
        public double Price { get; set; }

        public UpdateShoppingCartCommand(string userName, int gameId, string title, string titleUpdate, double price) {
            UserName = userName;
            GameId = gameId;
            Title = title;
            TitleUpdate = titleUpdate;
            Price = price;
        }
    }
}
