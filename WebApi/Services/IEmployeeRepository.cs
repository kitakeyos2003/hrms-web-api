using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IEmployeeRepository
    {
        List<EmployeeModel> GetAll();
        EmployeeModel Get(int id);
        EmployeeModel Add(EmployeeEntity employeeVM);
        void Update(EmployeeModel employeeVM);
        void Delete(int id);
    }
}
