

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Helpers;
using RentalService.Interfaces;
using RentalService.Models;
using RentalService.Models.ViewModels;
using System.Security.Claims;

namespace RentalService.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IRentalService _ICalendarService;
        private readonly UserManager<User> _UserManager;

        public CalendarController(IRentalService calendarinterface,UserManager<User> userManager)
        {
            _ICalendarService = calendarinterface;
            _UserManager = userManager;
        }

        public IActionResult ViewCalendar()
        {
            ViewData["Resources"] = JSONListHelper.GetResourcesListJSONString(_ICalendarService.GetEquipments());
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_ICalendarService.GetRentals());
            return View();
        }

     
    }
}
