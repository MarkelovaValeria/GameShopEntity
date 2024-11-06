using GameShopEntity.BusinessLogicalLayer.DTO.Request;
using GameShopEntity.BusinessLogicalLayer.DTO.Response;
using GameShopEntity.BusinessLogicalLayer.Interface.Services;
using GameShopEntity.Grpc;
using Microsoft.AspNetCore.Mvc;

namespace GameShopEntity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGamesService gameService;
        private readonly GameGrpcClientService gameGrpcClientService;
        private readonly GameAggregatorService gameAggregatorService;


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BusinessLogicalLayer.DTO.Response.GameResponse>> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                return Ok(await gameService.GetGamesByIdAsync(id));
            }
            /*catch (EntityNotFoundException e)
            {
                return NotFound(new { e.Message });
            }*/
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("gameCategory/{gameId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GameCategoryResponse>> GetCategoriesByGameId([FromRoute] int gameId)
        {
            try
            {
                return Ok(await gameService.GetCategoriesByGameId(gameId));
                
            }
            /*catch (EntityNotFoundException e)
            {
                return NotFound(new { e.Message });
            }*/
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateGame([FromBody] BusinessLogicalLayer.DTO.Request.GameRequest gameCreateRequest)
        {
            try
            {
                await gameService.CreateGame(gameCreateRequest);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("getGamesStream")]
        public async Task<IActionResult> GetGamesStream()
        {
            await gameGrpcClientService.GetGamesStreamAsync();
            return Ok();
        }

        [HttpPost("streamGameData")]
        public async Task<IActionResult> StreamGameData()
        {
            await gameGrpcClientService.StreamGameDataAsync(); 
            return Ok();
        }

        [HttpGet("aggregated/{gameId}/{categoryId}")]
        public async Task<IActionResult> GetAggregatedGameData([FromRoute] int gameId, int categoryId)
        {
            try
            {
                var aggregatedData = await gameAggregatorService.GetAggregatedGameDataAsync(gameId, categoryId);
                return Ok(aggregatedData);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }


        public GameController(IGamesService gamesService, GameGrpcClientService gameGrpcClientService)
        {
            gameService = gamesService;
            this.gameGrpcClientService = gameGrpcClientService;
        }
    }
}
