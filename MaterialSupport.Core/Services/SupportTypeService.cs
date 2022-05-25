using AutoMapper;
using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using MaterialSupport.DB;
using MaterialSupport.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Services
{
    public class SupportTypeService : ISupportTypeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SupportTypeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SupportTypeDto> GetById(int supportTypeId)
        {
            var result = await _context.SupportTypes.FirstOrDefaultAsync(sp => sp.Id.Equals(supportTypeId));

            return _mapper.Map<SupportTypeDto>(result);
        }

        public async Task<List<SupportTypeDto>> GetAll()
        {
            var result = await _context.SupportTypes.ToListAsync();

            return _mapper.Map<List<SupportTypeDto>>(result);
        }

        public async Task<SupportTypeDto> Add(SupportTypeDto supportType)
        {
            var check = await _context.SupportTypes.FirstOrDefaultAsync(sp => sp.Name.Equals(supportType.Name));

            if (check != null) throw new Exception("Такой тип материальной поддержки уже существует.");

            _context.SupportTypes.Add(_mapper.Map<SupportType>(supportType));
            await _context.SaveChangesAsync();

            return supportType;
        }

        public async Task<List<SupportTypeDto>> Remove(int supportTypeId)
        {
            var check = await _context.SupportTypes.FirstOrDefaultAsync(sp => sp.Id.Equals(supportTypeId));

            if (check == null) throw new Exception("Такого типа материальной поддержки не существует.");

            _context.SupportTypes.Remove(check);
            await _context.SaveChangesAsync();

            return _mapper.Map<List<SupportTypeDto>>(await _context.SupportTypes.ToListAsync());
        }

        public async Task<SupportTypeDto> Edit(SupportTypeDto supportType)
        {
            var dbSupportType = await _context.SupportTypes.FirstOrDefaultAsync(sp => sp.Id.Equals(supportType.Id));

            if (dbSupportType == null) throw new Exception("Такого типа материальной поддержки не существует.");

            dbSupportType.Name = supportType.Name;

            await _context.SaveChangesAsync();

            return _mapper.Map<SupportTypeDto>(dbSupportType);
        }
    }
}
