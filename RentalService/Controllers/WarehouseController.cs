

using RentalService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalService.Interfaces;
using RentalService.Services.Interfaces;
using RentalService.Models.ViewModels;

namespace RentalService.Controllers
{
    [Authorize]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        [HttpGet]

        public IActionResult List()
        {
            var equipments = _warehouseService.GetEquipments();
            return View(equipments); //Pobieranie listy ekwipunku
        }

        [HttpGet]
        public IActionResult CreateEquipment()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateEquipment(Equipment equipment)
        {

            if (!ModelState.IsValid)
            {
                return View(equipment);
            }

            var id = _warehouseService.Save(equipment);

            return RedirectToAction("List");


        }

      /*  [HttpGet]

        public IActionResult Update(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @equipment = _warehouseService.Get((int)id);

            if (@equipment == null)
            {
                return NotFound();
            }

            return View(@equipment);
        }


        [HttpPost]

        public async Task<IActionResult> Update(int id, Equipment equipment, IFormCollection form)
        {
            if (id != equipment.Id)
            {
                return NotFound();
            }


            try
            {
                _warehouseService.Update(form);
                TempData["Alert"] = "Success! You modified a rental for " + equipment.EquipmentName;
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
            }
            return View(equipment);
        }
      */
        

        [HttpGet]

        public IActionResult Details(int id)
        {
            var equipment = _warehouseService.GetEquipment(id);
            return View(equipment);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            _warehouseService.Delete(id);
            return RedirectToAction("List");
        }
    }
}

