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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var departmentList = await _departmentService.GetDepartmentList();
            return View(departmentList);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var department = await GetDepartmentById(id);
            var departmentConvertVM = Convert(department);
            return View(departmentConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var department = await GetDepartmentById(id);
            var departmentConvertVM = Convert(department);
            return View(departmentConvertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentConvertVM departmentConvertVM)
        {
            if (ModelState.IsValid)
            {
                var department = _mapper.Map<Department>(departmentConvertVM);
                await _departmentService.Update(department);
                return RedirectToAction("Index");
            }
            return View(departmentConvertVM);
        }
        [HttpGet]
        //public async Task<IActionResult> Create()
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentVM departmentVM)
        {
            if (ModelState.IsValid)
            {
                var department = _mapper.Map<Department>(departmentVM);
                await _departmentService.Add(department);
                return RedirectToAction("Index");
            }
            return View(departmentVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _departmentService.GetDepartmentById(id);
        }
        public DepartmentConvertVM Convert(Department department)
        {
            return _mapper.Map<DepartmentConvertVM>(department);
        }
    }
}
