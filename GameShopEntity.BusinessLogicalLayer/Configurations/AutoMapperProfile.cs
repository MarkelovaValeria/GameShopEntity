using AutoMapper;
using GameShopEntity.BusinessLogicalLayer.DTO.Request;
using GameShopEntity.BusinessLogicalLayer.DTO.Response;
using GameShopEntity.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.BusinessLogicalLayer.Configurations
{
    public class AutoMapperProfile : Profile
    {
        private void CreateGamesMaps()
        {
            CreateMap<GameRequest, Games>();
            CreateMap<Games, GameResponse>();
        }

        private void CreateGameCategoryMaps()
        {
            CreateMap<GameCategory, GameCategoryResponse>()
                .ForMember(
                response => response.Title,
                option => option.MapFrom(
                    game => game.Game.Title
                    )
                )
                .ForMember(
                response => response.Name,
                option => option.MapFrom(category => category.Category.Name)
                );
        }

        public AutoMapperProfile()
        {
            CreateGamesMaps();
            CreateGameCategoryMaps();
        }
    }
}
