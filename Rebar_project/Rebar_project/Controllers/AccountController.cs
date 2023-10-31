using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rebar_project.DataAccess;
using Rebar_project.Models;

namespace Rebar_project.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : Controller
    {
        private AccountDataAccess AccountManager = new AccountDataAccess();

        // POST: OrdersController/Create
        [HttpPost]
        public async Task<ActionResult> Create(Account account)
        {
            try
            {
                await AccountManager.AddAccount(account);
                return Ok("account added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //GET: shakesController
        [HttpGet]
        public async Task<IActionResult> GetAllAccount()
        {
            try
            {
                var shakes = await AccountManager.GetAccounts();
                return Ok(shakes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
