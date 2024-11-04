
using AutoMapper;
using ShoppingCartCQRS.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCQRS.Application.ShoppingCart.Queries.GetShoppingCart
{
    public class ShoppingCartItemVm : IMapFrom<ShoppingCartItem>
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public double Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ShoppingCartItem, ShoppingCartItemVm>();
        }
    }
}
