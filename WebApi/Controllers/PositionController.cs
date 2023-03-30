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
    [Authorize]
    public class PositionController : ControllerBase
    {
        private readonly IRepository<PositionModel, PositionEntity> repository;

        public PositionController(IRepository<PositionModel, PositionEntity> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Create(PositionModel model)
        {

            try
            {
                return Ok(repository.Add(new PositionEntity
                {
                    Name = model.Name,
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
        public IActionResult Update(PositionModel model)
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
