using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface IEmployeeService
    {
        Task<IList<Employee>> EmployeeWithDepartmentAsync();
        Task<IList<Employee>> EmployeeListByDepartment(string department);
        Task<Employee> GetEmployeeById(int id);
        Task<IList<Employee>> GetEmployeeList();
        Task Add(Employee employee);
        Task AddRange(List<Employee> employeeList);
        Task Update(Employee employee);
        Task Delete(int id);
    }
}
