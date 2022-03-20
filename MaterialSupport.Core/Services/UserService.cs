using MaterialSupport.Core.CustomExceptions;
using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using MaterialSupport.DB;
using MaterialSupport.DB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MaterialSupport.Core.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<UserDto> _passwordHasher;
        public UserService(AppDbContext context, IPasswordHasher<UserDto> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> Register(UserDto user)
        {
            var checkUsername = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.Equals(user.Username));

            if (checkUsername != null)
            {
                throw new UsernameAlreadyExistsException("Username already exists");
            }

            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = _passwordHasher.HashPassword(user, user.Password);
            }

            User newUser = new()
            {
                Username = user.Username,
                Password = user.Password,
                Role = user.Role,
                Student = user.Student != null ? new()
                {
                    Surname = user.Student?.Surname,
                    Name = user.Student.Name,
                    Lastname = user.Student.Lastname,
                    Group = user.Student.Group,
                    Gender = user.Student.Gender,
                    Birthday = user.Student.Birthday,
                    Birthplace = user.Student.Birthplace,
                    Citizenship = user.Student.Citizenship
                } : null,
                Employee = user.Employee != null ? new()
                {
                    Surname = user.Employee.Surname,
                    Name = user.Employee.Name,
                    Lastname = user.Employee.Lastname
                } : null
            };

            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return user;

        }
    }
}
