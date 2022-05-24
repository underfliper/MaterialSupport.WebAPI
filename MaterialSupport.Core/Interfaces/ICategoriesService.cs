using MaterialSupport.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<CategoryDto>> GetAll();
    }
}
