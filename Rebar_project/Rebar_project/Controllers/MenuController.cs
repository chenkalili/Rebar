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

        private static List<ShakeMenu> Menu = new List<ShakeMenu>();

        // POST: shakesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(ShakeMenu shake)
        {
            try
            {
                await ShakeManager.AddShake(shake);
                Menu.Add(shake);
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
    }
}
