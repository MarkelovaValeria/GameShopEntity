using MediatR;
using ShoppingCartCQRS.Application.ShoppingCart.Commands.CreateShoppingCart;
using ShoppingCartCQRS.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Application.ShoppingCart.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommandHandler : IRequestHandler<DeleteShoppingCartCommand, bool>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public DeleteShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<bool> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var existingCart = await _shoppingCartRepository.GetShoppingCartAsync(request.UserName);
            if (existingCart == null)
            {
                return false;
            }

            await _shoppingCartRepository.DeleteShoppingCartAsync(existingCart.UserName);

            return true;
        }
    }
}
