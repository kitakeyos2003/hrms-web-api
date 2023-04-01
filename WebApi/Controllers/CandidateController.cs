using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IRepository<CandidateModel, CandidateEntity> repository;

        public CandidateController(IRepository<CandidateModel, CandidateEntity> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Create(CandidateModel model)
        {

            try
            {
                return Ok(repository.Add(new CandidateEntity
                {
                    CandidateID = model.CandidateID,
                    FullName = model.FullName,
                    ContactInformation = model.ContactInformation,
                    Education = model.Education,
                    DepartmentApplied = model.DepartmentApplied.Id,
                    PositionApplied = model.PositionApplied.Id,
                    Skills = model.Skills,
                    WorkExperience = model.WorkExperience,
                    InterviewDate = model.InterviewDate,
                    Interviewer = model.Interviewer,
                    InterviewResult = model.InterviewResult,
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
        public IActionResult Update(CandidateModel model)
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
