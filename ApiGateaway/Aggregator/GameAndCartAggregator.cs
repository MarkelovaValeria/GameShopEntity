using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;
using System.Text;

public class GameAndCartAggregator : IDefinedAggregator
{
    public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
    {
        var gameResponse = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
        var cartResponse = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

        var aggregatedResult = $"{{\"gameDetails\": {gameResponse}, \"shoppingCart\": {cartResponse}}}";
        var stringContent = new StringContent(aggregatedResult, Encoding.UTF8, "application/json");

        var headers = responses.SelectMany(x => x.Items.DownstreamResponse().Headers).ToList();
        return new DownstreamResponse(stringContent, HttpStatusCode.OK, headers, "application/json");
    }
}
