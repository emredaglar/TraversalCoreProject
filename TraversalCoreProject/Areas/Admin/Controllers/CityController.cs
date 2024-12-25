using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination([FromBody] Destination destination)
        {
            if (destination == null)
            {
                return BadRequest("Eksik veya hatalı veri gönderildi.");
            }

            destination.Status = true;
            _destinationService.TAdd(destination);

            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var values = _destinationService.TGetById(id);
            return Json(values);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetById(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        [HttpPost]
        public IActionResult UpdateCity([FromBody] Destination destination)
        {

            if (string.IsNullOrEmpty(destination.City) || string.IsNullOrEmpty(destination.DayNight) || destination.DestinationId <= 0)
            {
                return Json(new { success = false, message = "Lütfen tüm alanları doldurun." });
            }

            _destinationService.TUpdate(destination);
            Console.WriteLine("Güncelleme başarılı!");
            return Json(new { success = true, message = "Şehir başarıyla güncellendi." });

        }
    }
}
