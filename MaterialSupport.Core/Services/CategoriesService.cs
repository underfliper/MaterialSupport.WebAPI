using AutoMapper;
using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using MaterialSupport.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();

            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
