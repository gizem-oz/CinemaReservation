using Cinema.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Components.SeatList
{
    public class SeatList:ViewComponent
    {
        private readonly ISeatService _seatService;
        private readonly ITicketService _ticketService;
        public SeatList(ISeatService seatService,ITicketService ticketService)
        {
            _seatService = seatService;
            _ticketService = ticketService;


        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _seatService.SeatWithRoom();
            return View(list);
        }
    }
}
