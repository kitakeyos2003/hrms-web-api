using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalaryController : ControllerBase
    {
        private readonly IRepository<SalaryModel, SalaryEntity> repository;

        public SalaryController(IRepository<SalaryModel, SalaryEntity> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Create(SalaryModel model)
        {

            try
            {
                return Ok(repository.Add(new SalaryEntity
                {
                    EmployeeID = model.Employee.EmployeeID,
                    Allowance = model.Allowance,
                    BasicSalary = model.BasicSalary,
                    Bonus = model.Bonus,
                    Deductions = model.Deductions,
                    GrossSalary = model.GrossSalary,
                    NetSalary = model.NetSalary,
                    PaymentDate = model.PaymentDate,
                    PaymentMethod = model.PaymentMethod,
                    PaySlip = model.PaySlip,
                    Tax = model.Tax
                }));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
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

        [HttpGet("{{id}}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(repository.Get(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(SalaryModel model)
        {
            try
            {
                repository.Update(model);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                repository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
