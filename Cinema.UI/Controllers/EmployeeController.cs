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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var employeeList = await _employeeService.EmployeeWithDepartmentAsync();
            return View(employeeList);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await GetEmployeeById(id);
            var employeeConvertVM = Convert(employee);
            return View(employeeConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var employee = await GetEmployeeById(id);
            var employeeConvertVM = Convert(employee);
            return View(employeeConvertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeConvertVM employeeConvertVM)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(employeeConvertVM);
                await _employeeService.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employeeConvertVM);
        }
        [HttpGet]
        //public async Task<IActionResult> Create()
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(employeeVM);
                await _employeeService.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employeeVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeService.GetEmployeeById(id);
        }
        public EmployeeConvertVM Convert(Employee employee)
        {
            return _mapper.Map<EmployeeConvertVM>(employee);
        }
    }
}
