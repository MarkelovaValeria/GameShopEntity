using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Application.ShoppingCart.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommand : IRequest<bool>
    {
        public string UserName { get; set; }

        public DeleteShoppingCartCommand(string userName)
        {
            UserName = userName;
        }
    }
}
