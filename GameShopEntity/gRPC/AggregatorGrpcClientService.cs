using GameShopEntityAggregator.Grpc;

namespace GameShopEntity.gRPC
{
    public class AggregatorGrpcClientService
    {
        private readonly AggregatorService.AggregatorServiceClient _aggregatorServiceClient;

        public AggregatorGrpcClientService(AggregatorService.AggregatorServiceClient aggregatorServiceClient)
        {
            _aggregatorServiceClient = aggregatorServiceClient;
        }

        public async Task GetAggregatedGameDataAsync(int gameId)
        {
            var request = new AggregatedRequest { GameId = gameId };
            var response = await _aggregatorServiceClient.GetAggregatedGameDataAsync(request);

            Console.WriteLine($"Game: {response.GameData.Title}, Category: {response.CategoryData.CategoryName}");
        }
    }

}
