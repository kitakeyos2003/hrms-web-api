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
    public class AttendanceController : Controller
    {
        private readonly IRepository<AttendanceModel, AttendanceEntity> repository;

        public AttendanceController(IRepository<AttendanceModel, AttendanceEntity> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Create(AttendanceModel model)
        {

            try
            {
                return Ok(repository.Add(new AttendanceEntity
                {
                    EmployeeID = model.Employee.EmployeeID,
                    ActualStartTime = model.ActualStartTime,
                    ActualEndTime = model.ActualEndTime,
                    AttendanceNote = model.AttendanceNote,
                    ShiftStartTime = model.ShiftStartTime,
                    ShiftEndTime = model.ShiftEndTime,
                    Overtime = model.Overtime,
                    Date = model.Date,
                    AttendanceStatus = model.AttendanceStatus,
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
        public IActionResult Update(AttendanceModel model)
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
