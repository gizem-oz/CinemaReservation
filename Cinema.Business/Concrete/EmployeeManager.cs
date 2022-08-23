using Cinema.Business.Abstract;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Concrete
{
    public class EmployeeManager:IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public async Task Add(Employee employee)
        {
                await _employeeDal.Add(employee);
        }

        public async Task AddRange(List<Employee> employeeList)
        {
            if (employeeList.Count>0)
            {
                await _employeeDal.AddRange(employeeList);
            }
        }

        public async Task Delete(int id)
        {
            Employee employee = await GetEmployeeById(id);
            if (employee != null)
            {
                employee.Status = false;
                await _employeeDal.Update(employee);
            }
        }

        public async Task<IList<Employee>> EmployeeListByDepartment(string department)
        {
            return await _employeeDal.GetAll(x=>x.Department.Name.Contains(department));
        }

        public async Task<IList<Employee>> EmployeeWithDepartmentAsync()
        {
            return await _employeeDal.EmployeeWithDepartmentAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeDal.Get(x=>x.AppIdentityUserId == id);
        }

        public async Task<IList<Employee>> GetEmployeeList()
        {
            return await _employeeDal.GetAll(x => x.Status == true);
        }

        public async Task Update(Employee employee)
        {
            await _employeeDal.Update(employee);
        }
    }
}
