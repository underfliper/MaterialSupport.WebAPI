using MaterialSupport.Core.Dto;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Register(UserDto user);
    }
}
