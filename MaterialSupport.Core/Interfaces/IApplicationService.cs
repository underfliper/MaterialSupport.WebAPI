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
        Task<List<DocumentDto>> GetApplicationDocs(int applicationId);
        Task<List<SupportTypeDto>> GetApplicationSupportTypes(int applicationId);
        Task<ApplicationDto> Accept(int applicationId);
        Task<ApplicationDto> Approve(int applicationId, int supportTypeId);
        Task<ApplicationDto> Reject(int applicationId);
    }
}
