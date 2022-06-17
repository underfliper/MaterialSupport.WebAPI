using AutoMapper;
using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using MaterialSupport.DB;
using MaterialSupport.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<CategoryDto> GetById(int categoryId)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(categoryId));

            return _mapper.Map<CategoryDto>(result);
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();

            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> Add(CategoryDto category)
        {
            var check = await _context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(category.Name));

            if (check != null) throw new Exception("Такая категория нуждаемости уже существует.");

            _context.Categories.Add(_mapper.Map<Category>(category));
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<CategoryDto> Edit(CategoryDto category)
        {
            var dbCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(category.Id));

            if (dbCategory == null) throw new Exception("Такая категория нуждаемости не существует.");

            dbCategory.Name = dbCategory.Name;

            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(dbCategory);
        }

        public async Task<List<CategoryDto>> Remove(int categoryId)
        {
            var check = await _context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(categoryId));

            if (check == null) throw new Exception("Такая категория нуждаемости не существует.");

            _context.Categories.Remove(check);
            await _context.SaveChangesAsync();

            return _mapper.Map<List<CategoryDto>>(await _context.Categories.ToListAsync());
        }
    }
}
