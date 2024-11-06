using AutoMapper;
using GameShopEntity.BusinessLogicalLayer.DTO.Request;
using GameShopEntity.BusinessLogicalLayer.DTO.Response;
using GameShopEntity.BusinessLogicalLayer.Interface.Services;
using GameShopEntity.DataAccessLayer.Entities;
using GameShopEntity.DataAccessLayer.Interface;
using GameShopEntity.DataAccessLayer.Interface.Repositories;
using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameShopEntity.BusinessLogicalLayer.Service
{
    public class GameService : IGamesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGameRepository gameRepository;
        private readonly IMemoryCache cache;
        private readonly IMapper mapper;
        private readonly IDistributedCache cacheRedis;
        private readonly IPublishEndpoint publishEndpoint;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache, IDistributedCache cacheRedis, IPublishEndpoint publishEndpoint)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.gameRepository = this.unitOfWork.GameRepository;
            this.cache = cache;
            this.cacheRedis = cacheRedis ?? throw new ArgumentNullException(nameof(cacheRedis));
            this.publishEndpoint = publishEndpoint;
        }

        public async Task<GameResponse> GetGamesByIdAsync(int id)
        {
            string cacheKey = $"Game_{id}";
            Console.WriteLine("Cache Redis: " + (cacheRedis == null ? "null" : "initialized"));


            
            var cachedGame = await cacheRedis.GetStringAsync(cacheKey);
            if (cachedGame != null)
            {
                return JsonSerializer.Deserialize<GameResponse>(cachedGame);
            }

            // Якщо дані не в кеші, отримуємо гру з репозиторію
            var game = await gameRepository.GetGamesByIdAsync(id);
            var gameResponse = mapper.Map<Games, GameResponse>(game);

            await cacheRedis.SetStringAsync(cacheKey, JsonSerializer.Serialize(gameResponse),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });

            return gameResponse;
        }

        public async Task<IEnumerable<GameCategoryResponse>> GetCategoriesByGameId(int id)
        {
            string cacheKey = $"GameCategories_{id}";

            if (!cache.TryGetValue(cacheKey, out IEnumerable<GameCategoryResponse> categoryResponses))
            {
                Console.WriteLine("Hello");
                var categories = await gameRepository.GetCategoriesByGameId(id);
                categoryResponses = categories.Select(mapper.Map<GameCategory, GameCategoryResponse>);

                cache.Set(cacheKey, categoryResponses, TimeSpan.FromMinutes(10));
            }
            Console.WriteLine("World");

            return categoryResponses;
        }

        public async Task CreateGame(GameRequest gameCreate)
        {
            var game = new Games
            {
                Title = gameCreate.Title,
                Description = gameCreate.Description,
                Developer = gameCreate.Developer,
                Publisher = gameCreate.Publisher,
                Price = gameCreate.Price,
                ReleaseDate = DateTime.Now,
                AverageRating = 0,
            };

            await gameRepository.InsertAsync(game);

            foreach (var categoryId in gameCreate.CategoryId)
            {
                var gameCategory = new GameCategory
                {
                    GameId = game.Id,
                    CategoryId = categoryId
                };
                await gameRepository.AddGameCategoryAsync(gameCategory);
            }

            await unitOfWork.SaveChangesAsync();

            cache.Remove("AllGames");

            var gameCreatedEvent = new GameCreatedEvent
            {
                GameId = game.Id,
                Title = game.Title,
                Price = game.Price
            };

            await publishEndpoint.Publish(gameCreatedEvent);
        }
    }
}
