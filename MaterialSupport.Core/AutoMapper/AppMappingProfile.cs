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
			CreateMap<StudentDto, Student>();
			CreateMap<EmployeeDto, Employee>();
		}
	}
}
