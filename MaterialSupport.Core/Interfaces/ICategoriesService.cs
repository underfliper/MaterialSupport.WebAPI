using MaterialSupport.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Interfaces
{
    public interface ICategoriesService
    {
        Task<CategoryDto> GetById(int categoryId);
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto> Add(CategoryDto category);
        Task<CategoryDto> Edit(CategoryDto category);
        Task<List<CategoryDto>> Remove(int categoryId);
    }
}
