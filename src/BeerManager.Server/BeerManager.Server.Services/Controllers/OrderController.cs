using AutoMapper;
using BeerManager.Core.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BeerManager.Server.Services.Controllers
{
    [ApiController, ApiExplorerSettings(GroupName = "beerManager")]
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private ICoreContext Context { get; }
        private IMapper Mapper { get; }

        public OrderController(IMapper mapper)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="orderId">Payment Id</param>
        /// <returns>Order</returns>
        /// <response code="200">Order</response>
        /// <response code="404">Order not found</response>
        [HttpGet("{orderId:guid}", Name = "getOrder")]
        [ProducesResponseType(typeof(Models.Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid orderId)
        {
            var orderModel = Context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (orderModel == null)
                return NotFound();

            return Ok(orderModel);
        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="product">Product definition</param>
        /// <returns>Created order</returns>
        /// <response code="200">Order</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        [ProducesResponseType(typeof(Models.Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody][Required] Models.Order order)
        {
            var model = Mapper.Map<Order>(order);
            Context.Orders.Add(model);
            await Context.SaveChangesAsync();

            var result = Mapper.Map<Models.Order>(model);

            return CreatedAtRoute("getOrder", new { productId = model.OrderId }, result);
        }
    }
}
