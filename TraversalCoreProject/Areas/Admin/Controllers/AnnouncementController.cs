﻿using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AnnouncementController : Controller
	{
		private readonly IAnnouncementService _announcementService;
		private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
		{
			//1
			//var values = _announcementService.TGetList();

			//2
			//List<Announcement> announcements=_announcementService.TGetList();
			//List<AnnouncementListViewModel> model = new List<AnnouncementListViewModel>();
			//foreach (var item in announcements)
			//{
			//	AnnouncementListViewModel announcementListViewModel = new AnnouncementListViewModel();
			//	announcementListViewModel.Title = item.Title;
			//	announcementListViewModel.Id=item.AnnouncementId;
			//	announcementListViewModel.Content = item.Content;	
			//	model.Add(announcementListViewModel);
			//}
			
			//3
			var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());
			return View(values);
		}

		[HttpGet]
		public IActionResult AddAnnouncement()
		{

			return View();
		}

		[HttpPost]
		public IActionResult AddAnnouncement(AnnouncementAddDTO model)
		{
			if (ModelState.IsValid)
			{
				_announcementService.TAdd(new Announcement()
				{
					Content = model.Content,
					Title = model.Title,
					AnnouncementDate=Convert.ToDateTime(DateTime.Now.ToShortDateString())
				});
				return RedirectToAction ("Index");
			}
			return View(model);
		}
		public IActionResult DeleteAnnouncement(int id)
		{
			var values=_announcementService.TGetById(id);
			_announcementService.TDelete(values);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateAnnouncement(int id)
		{
			var values = _mapper.Map<AnnouncementUpdateDto>(_announcementService.TGetById(id));
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateAnnouncement(AnnouncementUpdateDto model)
		{
			if (ModelState.IsValid)
			{
				_announcementService.TUpdate(new Announcement()
				{
					AnnouncementId = model.AnnouncementId,
					Content = model.Content,
					Title = model.Title,
					AnnouncementDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
				});
				return RedirectToAction("Index");
			}
			return View(model);
		}
	}
}
