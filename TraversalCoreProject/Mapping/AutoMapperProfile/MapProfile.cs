using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProject.Mapping.AutoMapperProfile
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<AnnouncementAddDTO, Announcement>();
			CreateMap<Announcement, AnnouncementAddDTO>();

			CreateMap<AppUserRegisterDTOs, AppUser>();
			CreateMap<AppUser, AppUserRegisterDTOs>();

			CreateMap<AppUserLoginDTOs, AppUser>();
			CreateMap<AppUser, AppUserLoginDTOs>();

			CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();
			CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();
			CreateMap<AnnouncementUpdateDto, Announcement>().ReverseMap();
			
			
		}
	}
}
