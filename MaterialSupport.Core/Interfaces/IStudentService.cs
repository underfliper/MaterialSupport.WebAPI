using MaterialSupport.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> GetStudent(int userId);
        Task<StudentDto> EditContacts(int userId, ContactsDto contacts);
        Task<List<ApplicationDto>> GetApplications(int studentId);
    }
}
