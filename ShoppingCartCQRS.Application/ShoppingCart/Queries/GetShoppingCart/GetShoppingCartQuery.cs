using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Application.ShoppingCart.Queries.GetShoppingCart
{
    public class GetShoppingCartQuery : IRequest<List<ShoppingCartItemVm>>
    {
        public string UserName { get; set; }

        public GetShoppingCartQuery(string userName)
        {
            UserName = userName;
        }
    }
}
