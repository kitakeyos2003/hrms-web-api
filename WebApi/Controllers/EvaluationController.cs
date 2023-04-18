using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase, ICrudService<EvaluateModel>
    {
        private readonly IRepository<EvaluateModel, EvaluateEntity> repository;

        public EvaluationController(IRepository<EvaluateModel, EvaluateEntity> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Create(EvaluateModel model)
        {

            try
            {
                return Ok(repository.Add(new EvaluateEntity
                {
                    EmployeeID = model.Employee.EmployeeID,
                    EvaluationCriteria = model.EvaluationCriteria,
                    ManagerComment = model.ManagerComment,
                    EmployeeComment = model.EmployeeComment,
                    EvaluationPeriod = model.EvaluationPeriod,
                    ImprovementPlan = model.ImprovementPlan,
                    EvaluationScore = model.EvaluationScore,
                    EvaluationResult = model.EvaluationResult,
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
        public IActionResult Update(EvaluateModel model)
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
