using Cinema.Business.Abstract;
using Cinema.Entities.Concrete;
using Cinema.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthService _authService;
        private IDepartmentService _departmentService;

        public AccountController(IAuthService authService,IDepartmentService departmentService)
        {
            _authService = authService;
            _departmentService = departmentService;
            
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _authService.Login(model);
            if (result != null)
            {
                if (result.Succeeded)
                {
                    var loginUser = await _authService.GetUser(model.Email);
                    var role = await _authService.GetRole(model.Email);
                    if (role == "User")
                    {
                        return RedirectToAction("UserIndex", "Home");
                    }
                    else if (role == "Admin")
                    {
                        return RedirectToAction("AdminIndex", "Home");
                    }

                    return RedirectToAction("EmployeeIndex", "Home");
                }
            }

            ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı");
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await _authService.Logout();
            return RedirectToAction("Login");

        }
        [HttpGet]
        //public async Task<IActionResult> Register()
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var result = await _authService.Register(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(model);
        }
        //public async Task<IActionResult> EmployeeRegister()
        public async Task<IActionResult> EmployeeRegister()
        {
            var departments = await _departmentService.GetDepartmentList();
            ViewBag.Departments =departments;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeRegister(EmployeeRegisterDto model)
        {
            
            
            var result = await _authService.EmployeeRegister(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(model);
        }
        //public async Task<IActionResult> AdminRegister()
        public IActionResult AdminRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminRegister(AdminRegisterDto model)
        {
            var result = await _authService.AdminRegister(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(model);
        }
        
    }
}
