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
    [Authorize(Roles = "Admin,Employee")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var roomList = await _roomService.RoomList();
            return View(roomList);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var room = await GetRoomById(id);
            var roomConvertVM = Convert(room);
            return View(roomConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var room = await GetRoomById(id);
            var roomConvertVM = Convert(room);
            return View(roomConvertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(RoomConvertVM roomConvertVM)
        {
            if (ModelState.IsValid)
            {
                var room = _mapper.Map<Room>(roomConvertVM);
                await _roomService.Update(room);
                return RedirectToAction("Index");
            }
            return View(roomConvertVM);
        }
        [HttpGet]
        //public async Task<IActionResult> Create()
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoomVM roomVM)
        {
            if (ModelState.IsValid)
            {
                var room = _mapper.Map<Room>(roomVM);
                await _roomService.Add(room);
                return RedirectToAction("Index");
            }
            return View(roomVM);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _roomService.GetRoomById(id);
        }
        public RoomConvertVM Convert(Room room)
        {
            return _mapper.Map<RoomConvertVM>(room);
        }
    }
}
