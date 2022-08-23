using AutoMapper;
using Cinema.Business.Abstract;
using Cinema.Entities.Concrete;
using Cinema.Entities.Dtos;
using Cinema.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly ISeatService _seatService;
        public ReservationController(ISeatService seatService,IReservationService reservationService, IMapper mapper,IAuthService authService)
        {
            _seatService = seatService;
            _reservationService = reservationService;
            _mapper = mapper;
            _authService = authService;
        }
        public async Task<IActionResult> Index()
        {
            
           var user = await _authService.GetUserByName(User.Identity.Name);

            string role = await _authService.GetRole(user.Email);
            ViewBag.Role = role;

            var reservationList = await _reservationService.ReservationWitCustomerAndEmployeehAsync();
            
            return View(reservationList);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var reservation = await GetReservationById(id);
            var reservationConvertVM = Convert(reservation);
            return View(reservationConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var reservation = await GetReservationById(id);
            var reservationConvertVM = Convert(reservation);
            return View(reservationConvertVM);
        }
        [HttpPost]
        
        public async Task<IActionResult> Update(ReservationConvertVM reservationConvertVM)
        {
                var reservation = _mapper.Map<Reservation>(reservationConvertVM);
                reservation.Status = true;
                await _reservationService.Update(reservation);
                return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> UpdateConfirm(int id)
        {
            var reservation = await _reservationService.GetReservationById(id);
                reservation.Status = true;
                await _reservationService.Update(reservation);
                return RedirectToAction("Index");
           
        }
        [HttpGet]
        //public async Task<IActionResult> Create()
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReservationVM reservationVM)
        {
            if (ModelState.IsValid)
            {
                var reservation = _mapper.Map<Reservation>(reservationVM);
                await _reservationService.Add(reservation);
                return RedirectToAction("Index");
            }
            return View(reservationVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _reservationService.Delete(id);
            //var reservation = await _reservationService.ReservationIncludeSeat(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ReservationDelete(int id)
        {
            
            var reservation = await _reservationService.GetReservationById(id);
            var seat = await _seatService.GetSeatById(reservation.SeatId);
            seat.Status = true;
            await _seatService.Update(seat);
            await _reservationService.ReservationDelete(id);
            return RedirectToAction("Index");
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationService.GetReservationById(id);
        }
        public ReservationConvertVM Convert(Reservation reservation)
        {
            return _mapper.Map<ReservationConvertVM>(reservation);
        }
    }
}
