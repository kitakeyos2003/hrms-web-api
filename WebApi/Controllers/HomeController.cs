using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRepository<EmployeeModel, EmployeeEntity> repository;

        public HomeController(IRepository<EmployeeModel, EmployeeEntity> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetInfo()
        {
            List<EmployeeModel> employees = repository.GetAll();
            return Ok(new
            {
                TotalEmployees = employees.Count,
                NewEmployeesThisMonth = employees.Count,
                NewEmployeesLastMonth = 1,
                SuccessfulProbationThisMonth = employees.Count,
                SuccessfulProbationLastMonth = 1,
                ResignedThisMonth = 0,
                ResignedLastMonth= 1
            });
        }

        [Route("/version")]
        [HttpGet]
        public IActionResult GetVersion()
        {
            DateTime releaseDate = DateTime.Now;
            return Ok(new
            {
                VersionNumber = "1.0.0.0",
                ReleaseDate = releaseDate,
                Description = "Phần mềm quản lý nhân sự được thiết kế bởi nhóm 4\nKhoa: Cônng nghệ thông tin\nLớp: DCCNTT12.10.1 - Khóa: K12\nTrường Đại học công nghệ Đông Á",
                PhoneNumber = "0348xxxxxx",
                Email = "hrms.xxxxx@gmail.com"
            });
        }
    }
}
