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
    public class SalaryController : ControllerBase, ICrudService<SalaryModel>
    {
        private readonly IRepository<SalaryModel, SalaryEntity> repository;

        public SalaryController(IRepository<SalaryModel, SalaryEntity> repository)
        {
            this.repository = repository;
        }

        [HttpPost("GenerateSalary")]
        public IActionResult GenerateSalary(List<EmployeeModel> models, DateTime startDate, DateTime endDate)
        {
            try
            {
                SalaryRepository salaryRepository = (SalaryRepository) repository;
                return Ok(salaryRepository.Generate(models, startDate, endDate));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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
                    Tax = model.Tax,
                    CreatedAt = model.CreatedAt,
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
