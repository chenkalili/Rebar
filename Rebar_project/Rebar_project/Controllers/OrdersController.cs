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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            try
            {
                var order = await OrderManager.GetOrderById(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/orders/1 (replace '1' with the actual order ID)
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(string id, [FromBody] OrderDB updatedOrder)
        {
            try
            {
                if (id != updatedOrder.OrderID.ToString())
                {
                    return BadRequest("Order ID in the request does not match the route.");
                }

                await OrderManager.UpdateOrder(updatedOrder);
                return Ok("Order updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/orders/1 (replace '1' with the actual order ID)
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(string id)
        {
            try
            {
                await OrderManager.DeleteOrder(id);
                return Ok("Order deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
