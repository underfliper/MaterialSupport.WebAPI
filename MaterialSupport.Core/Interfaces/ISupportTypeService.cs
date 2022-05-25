using MaterialSupport.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Interfaces
{
    public interface ISupportTypeService
    {
        Task<SupportTypeDto> GetById(int supportTypeId);
        Task<List<SupportTypeDto>> GetAll();
        Task<SupportTypeDto> Add(SupportTypeDto supportType);
        Task<SupportTypeDto> Edit(SupportTypeDto supportType);
        Task<List<SupportTypeDto>> Remove(int supportTypeId);
    }
}
