using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployeeById(int id);
        EmployeeDTO AddEmployee(EmployeeDTO employee);
        EmployeeDTO UpdateEmployee(EmployeeDTO employee);
        EmployeeDTO DeleteEmployee(int id);
    }
}
