using AutoMapper;
using MaterialSupport.Core.Dto;
using MaterialSupport.DB.Models;

namespace MaterialSupport.Core.AutoMapper
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<UserDto, User>();
			CreateMap<StudentDto, Student>().ReverseMap();
			CreateMap<EmployeeDto, Employee>();
			CreateMap<UserDto, RegisteredUser>();
			CreateMap<ContactsDto, StudentContacts>().ReverseMap();
			CreateMap<Category, CategoryDto>();
			CreateMap<Document, DocumentDto>();
			CreateMap<SupportType, SupportTypeDto>().ReverseMap();
			CreateMap<Application, ApplicationDto>();
			CreateMap<ApplicationsCategories, ApplicationsCategoriesDto>();
			CreateMap<ApplicationsSupportTypes, ApplicationsSupportTypesDto>();
			CreateMap<ApplicationsDocuments, ApplicationsDocumentsDto>();
			CreateMap<Application, ApplicationViewDto>()
				.ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Student.Surname))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Student.Name))
				.ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Student.Lastname))
				.ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Student.Group));
		}
	}
}
