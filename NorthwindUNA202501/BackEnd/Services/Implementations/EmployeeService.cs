using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;
        public EmployeeService(IUnidadDeTrabajo unidad)
        {
            _unidadDeTrabajo = unidad;
        }

        EmployeeDTO Convertir(Employee employee)
        {
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title
            };
        }

        Employee Convertir(EmployeeDTO employee)
        {
            return new Employee
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title
            };
        }


        public EmployeeDTO AddEmployee(EmployeeDTO employee)
        {
            _unidadDeTrabajo.EmployeeDAL.Add(Convertir(employee));
            _unidadDeTrabajo.Complete();
            return employee;
        }

        public EmployeeDTO DeleteEmployee(int id)
        {
            var Employee = new Employee { EmployeeId = id };
            _unidadDeTrabajo.EmployeeDAL.Remove(Employee);
            _unidadDeTrabajo.Complete();
            return Convertir(Employee);
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var result = _unidadDeTrabajo.EmployeeDAL.FindById(id);
            return Convertir(result);
        }

        public List<EmployeeDTO> GetEmployees()
        {
            var employees = _unidadDeTrabajo.EmployeeDAL.Get();
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
            foreach (var employee in employees)
            {
                employeeDTOs.Add(this.Convertir(employee));
            }
            return employeeDTOs;
        }

        public EmployeeDTO UpdateEmployee(EmployeeDTO employee)
        {
            var entity = Convertir(employee);
            _unidadDeTrabajo.EmployeeDAL.Update(entity);
            _unidadDeTrabajo.Complete();
            return employee;
        }
    }
}
