using MaterialSupport.Core.Dto;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Interfaces
{
    public interface IUserService
    {
        Task<RegisteredUser> Register(UserDto user);
    }
}
