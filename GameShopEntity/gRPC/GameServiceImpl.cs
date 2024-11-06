using GameShopEntity.Grpc;
using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GameServiceImpl : GameService.GameServiceBase
{
    
    public override async Task GetGamesStream(GameRequest request, IServerStreamWriter<GameResponse> responseStream, ServerCallContext context)
    {
        
        var games = new List<GameResponse>
        {
            new GameResponse { Id = 1, Title = "Game 1", Description = "Description 1", Price = 29.99 },
            new GameResponse { Id = 2, Title = "Game 2", Description = "Description 2", Price = 19.99 }
        };

        foreach (var game in games)
        {
            await responseStream.WriteAsync(game);  
            await Task.Delay(1000);  
        }
    }

    public override async Task StreamGameData(
        IAsyncStreamReader<GameCreateRequest> requestStream,
        IServerStreamWriter<GameCreateResponse> responseStream,
        ServerCallContext context)
    {
        await foreach (var gameCreateRequest in requestStream.ReadAllAsync())
        {
            var response = new GameCreateResponse { Success = true, Message = "Game Created" };
            await responseStream.WriteAsync(response);  
        }
    }
}
