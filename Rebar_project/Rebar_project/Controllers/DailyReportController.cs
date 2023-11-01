using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rebar_project.DataAccess;
using Rebar_project.models;

namespace Rebar_project.Controllers
{
    [Route("api/DailyReport")]
    [ApiController]
    public class DailyReportController : Controller
    {
        private DailyReportDataAccess dailyReport = new DailyReportDataAccess();

        // POST: DailyReportController/Create
        [HttpPost]
        public async Task<ActionResult> Create(string password)
        {
            try
            {
                await dailyReport.AddDailyReport(password);
                return Ok("report added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //GET: DailyReport
        [HttpGet]
        public async Task<IActionResult> GetAllShakes()
        {
            try
            {
                var shakes = await dailyReport.GetDailyReport();
                return Ok(shakes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
