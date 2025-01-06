using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [AllowAnonymous]
    [Area("Member")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager=new DestinationManager(new EfDestinationDal()); 
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
		public IActionResult GetCitiesSearchByName(string searchString)
		{
			ViewData["PageTitle"] = "Tur Rotaları";

			ViewData["CurrentFilter"] = searchString;
			var values = from x in destinationManager.TGetList() select x;
			if (!string.IsNullOrEmpty(searchString))
			{
				values = values.Where(x => x.City.Contains(searchString));
			}
			return View(values.ToList());
		}
	}
}
