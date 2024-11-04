using AutoMapper;
using MediatR;
using ShoppingCartCQRS.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Application.ShoppingCart.Queries.GetShoppingCart
{
    public class GetShoppingCartQueryHandler : IRequestHandler<GetShoppingCartQuery, List<ShoppingCartItemVm>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;
        public GetShoppingCartQueryHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper) { 
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }
        public async Task<List<ShoppingCartItemVm>> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartAsync(request.UserName);
            /*var shoppingCartItem = shoppingCart.Items.Select(item => new ShoppingCartVm
            {
                Id = item.GameId,
                Title = item.GameTitle,
                Price = item.Price
            }).ToList();*/

            var shoppingCartItems = _mapper.Map<List<ShoppingCartItemVm>>(shoppingCart.Items);

            return shoppingCartItems;
        }
    }
}
