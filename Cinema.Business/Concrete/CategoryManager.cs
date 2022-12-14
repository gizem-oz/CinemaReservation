using Cinema.Business.Abstract;
using Cinema.Business.ValidationRules.FluentValidation;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public ValidationResult Validator(Category category)
        {
            CategoryValidator validations = new CategoryValidator();
            var result = validations.Validate(category);
            return result;
        }
        public async Task Add(Category category)
        {
            var result = Validator(category);
            if (result.IsValid)
            {
                var name = await _categoryDal.Get(x => x.Name == category.Name);
                if (name == null)
                {
                    await _categoryDal.Add(category);
                }
            }
                
        }
        public async Task AddRange(List<Category> categoryList)
        {
            if (categoryList.Count>0)
            {
                await _categoryDal.AddRange(categoryList);
            }
        }

        public async Task Delete(int id)
        {
            Category category = await GetCategoryById(id);
            if (category !=null)
            {
                category.Status = false;
                await Update(category);
            }
        }
        public async Task<Category> GetCategoryById(int id)
        {
            Category category = await _categoryDal.Get(x => x.Id == id);
            return category;
        }

        public async Task<IList<Category>> GetCategoryList()
        {
            return await _categoryDal.GetAll(x=>x.Status ==true);
        }

        public async Task Update(Category category)
        {
            var result = Validator(category);
            if (result.IsValid)
            {
                await _categoryDal.Update(category);
            }
        }
    }
}
