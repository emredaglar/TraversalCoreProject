﻿using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDto model)
        {
            var contact = _mapper.Map<ContactUs>(model);
            contact.MessageStatus = true;
            contact.MessageDate = DateTime.Now;
            _contactUsService.TAdd(contact);
           
            return RedirectToAction("Index");
        }
    }
}
