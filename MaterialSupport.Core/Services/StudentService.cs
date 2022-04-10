using AutoMapper;
using MaterialSupport.Core.CustomExceptions;
using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using MaterialSupport.DB;
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
            var dbStudent = await _context.Students.FirstOrDefaultAsync(s => s.User.Id == userId);

            if (dbStudent == null) 
                throw new StudentNotFoundException("Студент, соотвествующий данному пользователю, не найден.");

            return _mapper.Map<StudentDto>(dbStudent);

        }
    }
}
