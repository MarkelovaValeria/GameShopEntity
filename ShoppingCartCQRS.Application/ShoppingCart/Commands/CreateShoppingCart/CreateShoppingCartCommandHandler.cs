using MediatR;
using ShoppingCartCQRS.Application.ShoppingCart.Commands.CreateShoppingCart;
using ShoppingCartCQRS.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, bool>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public CreateShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<bool> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            
            var existingCart = await _shoppingCartRepository.GetShoppingCartAsync(request.UserName);
            if (existingCart != null)
            {
                return false;
            }

            var newCart = new ShoppingCart(request.UserName);

            await _shoppingCartRepository.CreateShoppingCartAsync(newCart);

            return true;
        }
    }

