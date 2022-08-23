using AutoMapper;
using Cinema.Business.Abstract;
using Cinema.Entities.Concrete;
using Cinema.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            var categoryList = await _categoryService.GetCategoryList();
            return View(categoryList);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await GetCategoryById(id);
            var categoryConvertVM = Convert(category);
            return View(categoryConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await GetCategoryById(id);
            var categoryConvertVM = Convert(category);
            return View(categoryConvertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryConvertVM categoryConvertVM)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryConvertVM);
                await _categoryService.Update(category);
                return RedirectToAction("Index");
            }
            return View(categoryConvertVM);
        }
        [HttpGet]
        //public async Task<IActionResult> Create()
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                var category =_mapper.Map<Category>(categoryVM);
                await _categoryService.Add(category);
                return RedirectToAction("Index");
            }
            return View(categoryVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryService.GetCategoryById(id);
        }
        public CategoryConvertVM Convert(Category category)
        {
            return _mapper.Map<CategoryConvertVM>(category);
        }
    }
}
