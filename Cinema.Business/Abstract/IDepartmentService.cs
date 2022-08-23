using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface IDepartmentService
    {
        Task<IList<Department>> DepartmanListByName(string name);
        Task<Department> GetDepartmentById(int id);
        Task<IList<Department>> GetDepartmentList();
        Task Add(Department department);
        Task AddRange(List<Department> departmentList);
        Task Update(Department department);
        Task Delete(int id);
    }
}
