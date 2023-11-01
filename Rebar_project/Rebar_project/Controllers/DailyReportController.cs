using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rebar_project.DataAccess;
using Rebar_project.models;
using Rebar_project.Models;

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
        // GET: api/DailyReport/"1"
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDailyReportById(string id)
        {
            try
            {
                var report = await dailyReport.GetDailyReportById(id);
                if (report == null)
                {
                    return NotFound();
                }
                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/DailyReport/1 (replace '1' with the actual report ID)
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDailyReport(string id, [FromBody] DailyReport report)
        {
            try
            {
                if (id != report.ReportID.ToString())
                {
                    return BadRequest("Report ID in the request does not match the route.");
                }

                await dailyReport.UpdateDailyReport(report);
                return Ok("Report updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/DailyReport/1 (replace '1' with the actual report ID)
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDailyReport(string id)
        {
            try
            {
                await dailyReport.DeleteDailyReport(id);
                return Ok("Report deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
