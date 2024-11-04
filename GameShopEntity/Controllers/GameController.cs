using GameShopEntity.BusinessLogicalLayer.DTO.Request;
using GameShopEntity.BusinessLogicalLayer.DTO.Response;
using GameShopEntity.BusinessLogicalLayer.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameShopEntity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGamesService gameService;


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GameResponse>> GetByIdAsync([FromRoute] int id)
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
        public async Task<ActionResult> CreateGame([FromBody] GameRequest gameCreateRequest)
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

        public GameController(IGamesService gamesService)
        {
            gameService = gamesService;
        }
    }
}
