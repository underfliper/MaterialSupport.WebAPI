using AutoMapper;
using MaterialSupport.Core.CustomExceptions;
using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using MaterialSupport.DB;
using MaterialSupport.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Services
{
    public class ApplicationService: IApplicationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ApplicationService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApplicationViewDto> GetById(int applicationId)
        {
            var application = await _context.Applications
                .Include(a => a.Student)
                .Include(a => a.Categories)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(a => a.Id.Equals(applicationId));

            return _mapper.Map<ApplicationViewDto>(application);
        }

        public async Task<List<ApplicationViewDto>> GetByStatus(Status status)
        {
            var applications = await _context.Applications
                .Include(a => a.Student)
                .Include(a => a.Categories)
                .ThenInclude(c => c.Category)
                .Where(a => a.Status.Equals(status))
                .ToListAsync();

            return _mapper.Map<List<ApplicationViewDto>>(applications);
        }

        public async Task<ApplicationDto> Add(int userId, ApplicationFormDto application)
        {
            Application newApplication = new();
            List<ApplicationsCategories> categories = new();
            List<ApplicationsDocuments> documents = new();

            var student = await _context.Students.FirstOrDefaultAsync(s => s.User.Id.Equals(userId));

            foreach (var item in application.Categories)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(item.Id));

                categories.Add(new ApplicationsCategories() { Category = category });
            }

            foreach(var item in application.Documents)
            {
                byte[] data = null;

                using var binaryReader = new BinaryReader(item.OpenReadStream());
                data = binaryReader.ReadBytes((int)item.Length);

                documents.Add(new ApplicationsDocuments() { Document = new Document() { Name = item.FileName, Data = data } });
            }

            newApplication.Date = DateTime.Now.Date;
            newApplication.Student = student ?? throw new StudentNotFoundException("Студент с таким Id пользователя не найден.");
            newApplication.Categories = categories;
            newApplication.Documents = documents;
            newApplication.Status = Status.RequiringConsideration;

            _context.Applications.Add(newApplication);
            await _context.SaveChangesAsync();

            return _mapper.Map<ApplicationDto>(newApplication);
        }
    }
}
