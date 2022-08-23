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
    public class DepartmentManager:IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public async Task Add(Department department)
        {
           var name = await _departmentDal.Get(d=>d.Name == department.Name);
            if (name == null)
            {
                await _departmentDal.Add(department);
            }
           
        }

        public async Task AddRange(List<Department> departmentList)
        {
            if (departmentList.Count>0)
            {
                await _departmentDal.AddRange(departmentList);
            }
        }

        public async Task Delete(int id)
        {
            Department department = await GetDepartmentById(id);
            if (department!=null)
            {
                department.Status = false;
                await Update(department);
            }
        }
        public async Task<IList<Department>> DepartmanListByName(string name)
        {
            return await _departmentDal.GetAll(x => x.Name.Contains(name));
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _departmentDal.Get(x => x.Id == id);
        }

        public async Task<IList<Department>> GetDepartmentList()
        {
            return await _departmentDal.GetAll(x => x.Status == true);
        }

        public async Task Update(Department department)
        {
            await _departmentDal.Update(department);
        }
    }
}
