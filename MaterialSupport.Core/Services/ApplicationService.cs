using AutoMapper;
using MaterialSupport.Core.CustomExceptions;
using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using MaterialSupport.DB;
using MaterialSupport.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            List<Application> applications = new();

            if (status.Equals(Status.Processed))
            {
                applications = await _context.Applications
                    .Include(a => a.Student)
                    .Include(a => a.Categories)
                    .ThenInclude(c => c.Category)
                    .Where(a => a.Status.Equals(Status.Approved) || a.Status.Equals(Status.Denied))
                    .ToListAsync();
            }
            else
            {
                applications = await _context.Applications
                    .Include(a => a.Student)
                    .Include(a => a.Categories)
                    .ThenInclude(c => c.Category)
                    .Where(a => a.Status.Equals(status))
                    .ToListAsync();
            }
            

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

        public async Task<List<DocumentDto>> GetApplicationDocs(int applicationId)
        {
            List<Document> result = new();

            var documents = await _context.ApplicationsDocuments
                .Where(ad => ad.Application.Id.Equals(applicationId))
                .Include(ad => ad.Document)
                .ToListAsync();

            foreach (var item in documents)
            {
                result.Add(item.Document);
            }

            return _mapper.Map<List<DocumentDto>>(result);
        }

        public async Task<List<SupportTypeDto>> GetApplicationSupportTypes(int applicationId)
        {
            List<SupportType> result = new();

            var supportTypes = await _context.ApplicationsSupportTypes
                .Where(asp => asp.Application.Id.Equals(applicationId))
                .Include(a => a.SupportType)
                .ToListAsync();

            foreach (var item in supportTypes)
            {
                result.Add(item.SupportType);
            }

            return _mapper.Map<List<SupportTypeDto>>(result);
        }

        public async Task<ApplicationDto> Accept(int applicationId)
        {
            var application = await _context.Applications
                .Include(a => a.SupportTypes)
                .FirstOrDefaultAsync(a => a.Id.Equals(applicationId));

            application.SupportTypes = await GetRecommendedSupportTypes(applicationId);

            application.Status = Status.PendingConfirmation;

            await _context.SaveChangesAsync();

            return _mapper.Map<ApplicationDto>(application);
        }

        public async Task<ApplicationDto> Approve(int applicationId, int supportTypeId)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(a => a.Id.Equals(applicationId));

            var supportTypes = await _context.ApplicationsSupportTypes
                .Where(a => a.SupportType.Id != supportTypeId && a.Application.Id.Equals(applicationId))
                .ToListAsync();

            application.Status = Status.Approved;
            _context.ApplicationsSupportTypes.RemoveRange(supportTypes);

            await _context.SaveChangesAsync();

            return _mapper.Map<ApplicationDto>(application);
        }

        public async Task<ApplicationDto> Reject(int applicationId)
        {
            var application = await _context.Applications
                .Include(a => a.SupportTypes)
                .FirstOrDefaultAsync(a => a.Id.Equals(applicationId));

            if (application.Status == Status.PendingConfirmation)
                _context.ApplicationsSupportTypes.RemoveRange(application.SupportTypes);

            application.Status = Status.Denied;

            await _context.SaveChangesAsync();

            return _mapper.Map<ApplicationDto>(application);
        }

        private async Task<List<ApplicationsSupportTypes>> GetRecommendedSupportTypes(int applicationId)
        {
            ProcessStartInfo start = new()
            {
                FileName = @"C:\Python310\python.exe",
                Arguments = string.Format("{0} {1}", @"..\MaterialSupport.Core\Utilities\Recommender.py", applicationId),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            Process process = Process.Start(start);
            using StreamReader reader = process.StandardOutput;
            string stderr = process.StandardError.ReadToEnd();
            string scriptResult = reader.ReadToEnd();

            scriptResult = scriptResult.Replace("Name: SupportType, dtype: int64", "");

            var temp = scriptResult.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> supportTypeIds = new();

            foreach (var item in temp)
            {
                supportTypeIds.Add(int.Parse(item.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]));
            }

            supportTypeIds = supportTypeIds.Distinct().ToList();

            List<ApplicationsSupportTypes> supportTypes = new();

            foreach(var item in supportTypeIds)
            {
                var supportType = await _context.SupportTypes.FirstOrDefaultAsync(sp => sp.Id.Equals(item));

                supportTypes.Add(new ApplicationsSupportTypes { SupportType = supportType });
            }

            return supportTypes;
        }
    }
}
