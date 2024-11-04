using MediatR;
using ShoppingCartCQRS.Application.ShoppingCart.Queries.GetShoppingCart;
using ShoppingCartCQRS.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Application.ShoppingCart.Commands.UpdateShoppingCart
{
    public class UpdateShoppingCartCommandHandler : IRequestHandler<UpdateShoppingCartCommand, int>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public UpdateShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<int> Handle(UpdateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var existingCart = await _shoppingCartRepository.GetShoppingCartAsync(request.UserName);
            if (existingCart == null)
            {
                throw new Exception("Такого юзера не існує");
            }

            var Item = existingCart.Items.Where(x => x.GameTitle == request.Title).Select(x => new ShoppingCartItem
            {
                GameId = request.GameId,
                GameTitle = request.TitleUpdate,
                Price = request.Price
            }).FirstOrDefault();

            return await _shoppingCartRepository.UpdateShoppingCartItemAsync(request.Title, Item);

        }

        
    }
}
