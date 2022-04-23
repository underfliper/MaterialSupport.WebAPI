using AutoMapper;
using MaterialSupport.Core.CustomExceptions;
using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using MaterialSupport.DB;
using MaterialSupport.DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> GetStudent(int userId)
        {
            var dbStudent = await _context.Students.Include(s => s.Contacts).FirstOrDefaultAsync(s => s.User.Id == userId);

            if (dbStudent == null)
                throw new StudentNotFoundException("Студент, соотвествующий данному пользователю, не найден.");

            return _mapper.Map<StudentDto>(dbStudent);

        }

        public async Task<StudentDto> EditContacts(int userId, ContactsDto contacts)
        {
            var dbStudent = await _context.Students.Include(s => s.Contacts).FirstOrDefaultAsync(s => s.User.Id == userId);

            if (dbStudent == null)
                throw new StudentNotFoundException("Студент, соотвествующий данному пользователю, не найден.");

            dbStudent.Contacts = _mapper.Map<StudentContacts>(contacts);

            await _context.SaveChangesAsync();

            return _mapper.Map<StudentDto>(dbStudent);
        }
    }
}
