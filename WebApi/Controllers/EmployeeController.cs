using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(EmployeeModel model)
        {
            try
            {
                return Ok(repository.Add(new EmployeeEntity
                {
                    FullName = model.FullName,
                    Address = model.Address,
                    BirthDay = model.BirthDay,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    DepartmentId = model.Department.Id,
                    Department = new DepartmentEntity
                    {
                        Id = model.Department.Id,
                        Name = model.Department.Name
                    },
                    PositionId = model.Position.Id,
                    Position = new PositionEntity
                    {
                        Id = model.Position.Id,
                        Name =model.Position.Name
                    }
                })); 
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(repository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
