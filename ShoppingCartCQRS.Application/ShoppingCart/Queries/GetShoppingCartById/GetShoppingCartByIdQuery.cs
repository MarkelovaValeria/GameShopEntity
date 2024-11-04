using MediatR;
using ShoppingCartCQRS.Application.ShoppingCart.Queries.GetShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Application.ShoppingCart.Queries.GetShoppingCartById
{
    public class GetShoppingCartByIdQuery : IRequest<ShoppingCartItemVm>
    {
        public string UserName { get; set; }
        public string Title { get; set; }

        public GetShoppingCartByIdQuery(string userName, string title)
        {
            UserName = userName;
            Title = title;
        }
    }
}
