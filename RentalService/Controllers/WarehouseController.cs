

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
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _IWarehouseService;
        private readonly UserManager<User> _usermanager;


        public WarehouseController(IWarehouseService iWarehouseService, UserManager<User> usermanager)
        {
            _IWarehouseService = iWarehouseService;
            _usermanager = usermanager;
        }
        public IActionResult List()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_IWarehouseService.GetEquipments(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }



        [HttpGet]
        public IActionResult CreateEquipment()
        {
            return View(new EquipmentViewModel(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [HttpPost]

        public async Task<IActionResult> CreateEquipment(EquipmentViewModel vm, IFormCollection form)
        {

            try
            {
                _IWarehouseService.CreateEquipment(form);
                TempData["Alert"] = "Success! You have created new equipment" + form["EquipmentName"];

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;

                return View(vm);
            }

        }


        [HttpGet]


        public IActionResult UpdateEquipment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var updatedEquipment = _IWarehouseService.GetEquipment((int)id);

            if (updatedEquipment == null)
            {
                return NotFound();
            }
            var vm = new EquipmentViewModel(updatedEquipment, User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(vm);
        }
        [HttpPost]

        public async Task<IActionResult> UpdateEquipment(int id, IFormCollection form)
        {
            try
            {
                _IWarehouseService.UpdateEquipment(form);
                TempData["Alert"] = "Success! You modified an rental for: " + form["Rental.RentedEquipmentName"];
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new EquipmentViewModel(_IWarehouseService.GetEquipment(id), User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View(vm);
            }


        }

        [HttpGet]

        public IActionResult DeleteEquipment(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = _IWarehouseService.GetEquipment(id);


            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }

        [HttpPost, ActionName("DeleteEquipment")]
        public IActionResult DeleteEquipmentConfirmed(int id)
        {
            _IWarehouseService.DeleteEquipment(id);
            TempData["Alert"] = "You have deleted equipment succesfully";

            return RedirectToAction("List");
        }
    }
}
