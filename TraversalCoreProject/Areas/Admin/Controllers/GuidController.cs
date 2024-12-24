using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuidController : Controller
    {
        private readonly IGuideService _guideService;

        public GuidController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToActive(int id)
        {

            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        public IActionResult ChangeToPassive(int id)
        {

            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
