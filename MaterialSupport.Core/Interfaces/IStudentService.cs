using MaterialSupport.Core.Dto;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> GetStudent(int userId);
    }
}
