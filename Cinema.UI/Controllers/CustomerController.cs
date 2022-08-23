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
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            var customerList = await _customerService.GetCustomerList();
            return View(customerList);
        }
        [HttpGet]
       
        public async Task<IActionResult> Details(int id)
        {
            var customer = await GetCustomerById(id);
            var customerConvertVM = Convert(customer);
            return View(customerConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var customer = await GetCustomerById(id);
            var customerConvertVM = Convert(customer);
            return View(customerConvertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomerConvertVM customerConvertVM)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(customerConvertVM);
                await _customerService.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customerConvertVM);
        }
        [HttpGet]
        //public async Task<IActionResult> Create()
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(customerVM);
                await _customerService.Add(customer);
                return RedirectToAction("Index");
            }
            return View(customerVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerService.GetCustomerById(id);
        }
        public CustomerConvertVM Convert(Customer customer)
        {
            return _mapper.Map<CustomerConvertVM>(customer);
        }
    }
}
