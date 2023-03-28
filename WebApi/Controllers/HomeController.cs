using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetInfo()
        {
            return Ok(new
            {
                TotalEmployees = 10,
                NewEmployeesThisMonth = 100,
                NewEmployeesLastMonth = 10,
                SuccessfulProbationThisMonth = 20,
                SuccessfulProbationLastMonth = 1,
                ResignedThisMonth = 10,
                ResignedLastMonth= 30
            });
        }
    }
}
