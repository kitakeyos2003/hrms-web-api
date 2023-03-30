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
    public class ContractController : ControllerBase
    {
        private readonly IRepository<ContractModel, ContractEntity> repository;

        public ContractController(IRepository<ContractModel, ContractEntity> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Create(ContractModel model)
        {

            try
            {
                return Ok(repository.Add(new ContractEntity
                {
                    EmployeeID = model.Employee.EmployeeID,
                    BasicSalary = model.BasicSalary,
                    ContractType = model.ContractType,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    WorkingTime = model.WorkingTime,
                    Note = model.Note,
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
        public IActionResult Update(ContractModel model)
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
