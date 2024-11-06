using Grpc.Net.Client;
using GameShopEntity.Grpc;
using System;
using System.Threading.Tasks;
using Grpc.Core;

public class GameGrpcClientService
{
    private readonly GameService.GameServiceClient _gameServiceClient;

    public GameGrpcClientService(GameService.GameServiceClient gameServiceClient)
    {
        _gameServiceClient = gameServiceClient;
    }

    public async Task GetGamesStreamAsync()
    {
        using var call = _gameServiceClient.GetGamesStream(new GameRequest());

        await foreach (var game in call.ResponseStream.ReadAllAsync())
        {
            Console.WriteLine($"Received Game: {game.Title}, {game.Description}");
        }
    }
    public async Task StreamGameDataAsync()
    {
        using var call = _gameServiceClient.StreamGameData();

        // Відправка даних до серверу
        await call.RequestStream.WriteAsync(new GameCreateRequest { Title = "New Game", Description = "A great game" });
        await call.RequestStream.CompleteAsync();

        
        await foreach (var response in call.ResponseStream.ReadAllAsync())
        {
            Console.WriteLine($"Response: {response.Message}");
        }
    }
}
