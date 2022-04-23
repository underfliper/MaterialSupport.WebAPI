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
		}
	}
}
