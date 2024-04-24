

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalService.Helpers;
using RentalService.Interfaces;
using RentalService.Models;
using System.Security.Claims;

namespace RentalService.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IRentalService _ICalendarService;
        private readonly UserManager<User> _UserManager;


        public CalendarController(IRentalService calendarinterface, UserManager<User> userManager)
        {
            _ICalendarService = calendarinterface;
            _UserManager = userManager;


        }

        [Authorize]
        public IActionResult ViewCalendar()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Resources"] = JSONListHelper.GetResourcesListJSONString(_ICalendarService.GetEquipments());
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_ICalendarService.GetRentals(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return View();
        }


    }
}
