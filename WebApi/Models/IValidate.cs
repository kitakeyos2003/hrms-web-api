using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models
{
    public interface IValidate<T>
    {
        Task<IActionResult> Validate(T model);
    }
}
