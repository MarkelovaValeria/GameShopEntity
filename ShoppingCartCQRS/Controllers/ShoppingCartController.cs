using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartCQRS.Application.ShoppingCart.Queries.GetShoppingCart;

namespace ShoppingCartCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ApiControllerBase
    {
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetShoppingCartAsync(string userName)
        {
            var query = new GetShoppingCartQuery(userName);
            var shoppingCartItems = await Mediator.Send(query);

            if (shoppingCartItems == null || !shoppingCartItems.Any())
            {
                return NotFound("Shopping cart is empty or user does not exist.");
            }

            return Ok(shoppingCartItems);
        }


    }
}
