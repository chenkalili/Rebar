using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rebar_project.DataAccess;
using Rebar_project.models;

namespace Rebar_project.Controllers
{
    [Route("api/shakes")]
    [ApiController]
    public class MenuController : Controller
    {
        private ShakesDataAccess ShakeManager=new ShakesDataAccess();

        // POST: shakesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(ShakeMenu shake)
        {
            try
            {
                await ShakeManager.AddShake(shake);
                return Ok("Shake added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //GET: shakesController
        [HttpGet]
        public async Task<IActionResult> GetAllShakes()
        {
            try
            {
                var shakes = await ShakeManager.GetShakes();
                return Ok(shakes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // GET: api/shakes/"1"
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShakeById(string id)
        {
            try
            {
                var shake = await ShakeManager.GetShakeById(id);
                if (shake == null)
                {
                    return NotFound();
                }
                return Ok(shake);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/shakes/'1'
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateShake(string id, [FromBody] ShakeMenu shake)
        {
            try
            {
                if (id != shake.ShakeID.ToString())
                {
                    return BadRequest("Shake ID in the request does not match the route.");
                }

                await ShakeManager.UpdateShake(shake);
                return Ok("Shake updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/shakes/'1'
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShake(string id)
        {
            try
            {
                await ShakeManager.DeleteShake(id);
                return Ok("Shake deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
