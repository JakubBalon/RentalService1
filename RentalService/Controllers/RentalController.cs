

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using RentalService.Interfaces;
using RentalService.Models;
using RentalService.Models.ViewModels;
using System.Security.Claims;

namespace RentalService.Controllers
{
    [Authorize]
    public class RentalController : Controller
    {
        private readonly IRentalService _IRentalService;
        private readonly UserManager<User> _usermanager;


        public RentalController(IRentalService iRentalService, UserManager<User> usermanager)
        {
            _IRentalService = iRentalService;
            _usermanager = usermanager;
        }
        public IActionResult ViewRentals()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_IRentalService.GetRentals(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        public IActionResult ViewRental(int id)
        {
            var @rental = _IRentalService.GetRental(id);
            if (@rental == null) { return NotFound(); }
            return View(@rental);
        }



        [HttpGet]
        public IActionResult CreateRental()
        {
            return View(new RentalViewModel(_IRentalService.GetEquipments(), User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [HttpPost]

        public async Task<IActionResult> CreateRental(RentalViewModel vm, IFormCollection form)
        {

            try
            {
                _IRentalService.CreateRental(form);
                TempData["Alert"] = "Success! You have created new rental" + form["EquipmentName"];

                return RedirectToAction("ViewRentals");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                return View(vm);
            }

        }


        [HttpGet]

        public IActionResult UpdateRental(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @rental = _IRentalService.GetRental((int)id);

            if (@rental == null)
            {
                return NotFound();
            }
            var vm = new RentalViewModel(@rental, _IRentalService.GetEquipments(), User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(vm);
        }
        [HttpPost]

        public async Task<IActionResult> UpdateRental(int id, IFormCollection form)
        {
            try
            {
                _IRentalService.UpdateRental(form);
                TempData["Alert"] = "Success! You modified an rental for: " + form["Rental.RentedEquipmentName"];
                return RedirectToAction(nameof(ViewRentals));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new RentalViewModel(_IRentalService.GetRental(id), _IRentalService.GetEquipments(), User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View(vm);
            }
        }

        [HttpGet]

        public IActionResult DeleteRental(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @rental = _IRentalService.GetRental(id);


            if (@rental == null)
            {
                return NotFound();
            }
            return View(@rental);
        }

        [HttpPost, ActionName("DeleteRental")]
        public IActionResult DeleteRentalConfirmed(int id)
        {
            _IRentalService.DeleteRental(id);
            TempData["Alert"] = "You have deleted rental succesfully";

            return RedirectToAction("ViewRentals");
        }
    }
}
