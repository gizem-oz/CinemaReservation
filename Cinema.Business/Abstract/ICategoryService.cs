using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryById(int id);
        Task<IList<Category>> GetCategoryList();
        Task Add(Category category);
        Task AddRange(List<Category> categoryList);
        Task Update(Category category);
        Task Delete(int id);
    }
}
