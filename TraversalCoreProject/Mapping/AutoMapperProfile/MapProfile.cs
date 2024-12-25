using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProject.Mapping.AutoMapperProfile
{
	public class MapProfile : Profile
	{
		protected MapProfile()
		{
			CreateMap<AnnouncementAddDTOs, Announcement>();
			CreateMap<Announcement, AnnouncementAddDTOs>();

			CreateMap<AppUserRegisterDTOs, AppUser>();
			CreateMap<AppUser, AppUserRegisterDTOs>();

			CreateMap<AppUserLoginDTOs, AppUser>();
			CreateMap<AppUser, AppUserLoginDTOs>();
		}
	}
}
