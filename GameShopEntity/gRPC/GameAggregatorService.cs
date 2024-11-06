using GameShopEntity.Grpc;
using GameShopEntityAggregator.Grpc;
using GameShopEntityCategory.Grpc;


public class GameAggregatorService
{
    private readonly GameService.GameServiceClient _gameServiceClient;
    private readonly CategoryService.CategoryServiceClient _categoryServiceClient;

    public GameAggregatorService(GameService.GameServiceClient gameServiceClient,
                                 CategoryService.CategoryServiceClient categoryServiceClient)
    {
        _gameServiceClient = gameServiceClient;
        _categoryServiceClient = categoryServiceClient;
    }

    public async Task<AggregatedResponse> GetAggregatedGameDataAsync(int gameId, int categoryId)
    {
        var gameResponse = await _gameServiceClient.GetGameByIdAsync(new GameRequest { Id = gameId });
        var categoryResponse = await _categoryServiceClient.GetCategoriesByGameIdAsync(new CategoryRequest { CategoryId = categoryId });

        return new AggregatedResponse
        {
            GameData = gameResponse,
            CategoryData = categoryResponse
        };
    }
}
