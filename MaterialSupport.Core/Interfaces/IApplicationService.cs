using MaterialSupport.Core.Dto;
using MaterialSupport.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Interfaces
{
    public interface IApplicationService
    {
        Task<ApplicationViewDto> GetById(int applicationId);
        Task<List<ApplicationViewDto>> GetByStatus(Status status);
        Task<ApplicationDto> Add(int userId, ApplicationFormDto application);
    }
}
