using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public interface ICrudService<E>
    {
        public IActionResult Create(E model);
        public IActionResult GetAll();
        public IActionResult Get(int id);
        public IActionResult Update(E model);
        public IActionResult Delete(int id);
    }
}
