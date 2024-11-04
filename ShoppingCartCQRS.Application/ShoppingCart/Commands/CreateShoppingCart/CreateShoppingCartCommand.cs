using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Application.ShoppingCart.Commands.CreateShoppingCart
{
    public class CreateShoppingCartCommand : IRequest<bool>
    {
        public string UserName { get; set; }

        public CreateShoppingCartCommand(string userName)
        {
            UserName = userName;
        }
    }
}
