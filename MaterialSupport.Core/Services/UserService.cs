using AutoMapper;
using MaterialSupport.Core.CustomExceptions;
using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using MaterialSupport.Core.Utilities;
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
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(AppDbContext context, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthenticatedUser> Login(LoginRequest loginRequest)
        {
            var dbUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginRequest.Username);

            if (dbUser == null ||
                dbUser.Password == null ||
                _passwordHasher.VerifyHashedPassword(dbUser, dbUser.Password, loginRequest.Password) == PasswordVerificationResult.Failed)
            {
                throw new InvalidUsernameOrPasswordException("Неверный логин или пароль");
            }

            return new AuthenticatedUser()
            {
                Username = loginRequest.Username,
                Token = JwtGenerator.GenerateAuthToken(dbUser)
            };
        }

        public async Task<RegisteredUser> Register(UserDto user)
        {
            var checkUsername = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.Equals(user.Username));

            if (checkUsername != null)
            {
                throw new UsernameAlreadyExistsException("Такой логин уже занят!");
            }

            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = _passwordHasher.HashPassword(checkUsername, user.Password);
            }

            var newUser = _mapper.Map<User>(user);

            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<RegisteredUser>(user);

        }
    }
}
