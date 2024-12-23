﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
	public class DestinationController : Controller
	{
		DestinationManager destinationManager=new DestinationManager(new EfDestinationDal());
		public IActionResult Index()
		{
			var values=destinationManager.TGetList();
			return View(values);
		}
        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            var values=destinationManager.TGetById(id);
            ViewBag.i = id;
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination destination)
        {

            return View();
        }
    }
}
