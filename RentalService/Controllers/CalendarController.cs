

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Interfaces;
using RentalService.Models;
using RentalService.Models.ViewModels;

namespace RentalService.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IRentalService _ICalendarService;

        public CalendarController(IRentalService calendarinterface)
        {
            _ICalendarService = calendarinterface;
        }

        public IActionResult ViewCalendar()
        {
            return View();
        }

       
    }
}
