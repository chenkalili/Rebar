using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rebar_project.DataAccess;
using Rebar_project.Models;

namespace Rebar_project.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : Controller
    {
        private OrderDataAccess OrderManager = new OrderDataAccess();

        // POST: OrdersController/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderModel orderModel)
        {
            try
            {
                await OrderManager.AddOrder(orderModel.ShakeOrder, orderModel.Discounts, orderModel.Name);
                return Ok("Order added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //GET: shakesController
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var shakes = await OrderManager.GetOrders();
                return Ok(shakes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
