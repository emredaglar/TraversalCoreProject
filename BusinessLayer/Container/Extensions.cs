﻿using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUow;
using BusinessLayer.ValidationRules.AnnouncementValidationRules;
using BusinessLayer.ValidationRules.ContactUsValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public class Extensions
    {
        public static void ContainerDependencies(IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();


            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

			services.AddScoped<IExcelService, ExcelManager>();

			services.AddScoped<IPdfService, PdfManager>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

			services.AddScoped<IAnnouncementService, AnnouncementManager>();
			services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

			services.AddScoped<IAccountService, AccountManager>();
			services.AddScoped<IAccountDal, EfAccountDal>();
			services.AddScoped<IUowDal, UowDal>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();
		}

        public static void CustomValidator(IServiceCollection services)
        {
			services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementAddValidator>();
			services.AddTransient<IValidator<SendMessageDto>, SendContactUsValidator>();
		}

    }
}
