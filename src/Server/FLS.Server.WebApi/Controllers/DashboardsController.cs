using FLS.Data.WebApi.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FLS.Server.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController : ControllerBase
    {
        // GET: api/<DashboardsController>
        [HttpGet]
        public ActionResult<DashboardDetails> Get()
        {
            var data = new DashboardDetails()
            {
                SafetyDashboardDetails = new SafetyDashboardDetails()
                {
                    Starts = 20,
                    FlightTimeInHours = 35,
                    StatisticBasedOnLastMonths = 6
                },
                PersonDashboardDetails = new PersonDashboardDetails()
                {
                    MedicalClass2ExpireDate = DateTime.Now.AddDays(100),
                    MedicalLaplExpireDate = DateTime.Now.AddDays(100).AddYears(1)
                }

            };

            return Ok(data);
        }
    }
}
