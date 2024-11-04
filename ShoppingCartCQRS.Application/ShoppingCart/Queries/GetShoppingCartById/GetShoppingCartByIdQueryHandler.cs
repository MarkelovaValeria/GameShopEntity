using AutoMapper;
using MediatR;
using ShoppingCartCQRS.Application.ShoppingCart.Queries.GetShoppingCart;
using ShoppingCartCQRS.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Application.ShoppingCart.Queries.GetShoppingCartById
{
    public class GetShoppingCartByIdQueryHandler : IRequestHandler<GetShoppingCartByIdQuery, ShoppingCartItemVm>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;
        public GetShoppingCartByIdQueryHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }
        public async Task<ShoppingCartItemVm> Handle(GetShoppingCartByIdQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartAsync(request.UserName);
            /*var item = shoppingCart.Items.Where(x => x.GameTitle == request.Title).Select(item=> new ShoppingCartVm
            {
                Id = item.GameId,
                Title = item.GameTitle,
                Price = item.Price
            }).FirstOrDefault();*/
            var item = shoppingCart.Items.FirstOrDefault(x => x.GameTitle == request.Title);

            return _mapper.Map<ShoppingCartItemVm>(item);
        }
    }
}
