using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationService _destinationService;

        public DashboardController(UserManager<AppUser> userManager, IDestinationService destinationService)
        {
            _userManager = userManager;
            _destinationService = destinationService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = values.Name + " " + values.Surname;
            ViewBag.userImage = values.ImageUrl;

            return View();
        }

        public async Task<IActionResult> MemberDashboard()
        {
            ViewData["PageTitle"] = "Üye - Dashboard";
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = values.Name + " " + values.Surname;
            ViewBag.userImage = values.ImageUrl;

            return View();
        }
    }
}
