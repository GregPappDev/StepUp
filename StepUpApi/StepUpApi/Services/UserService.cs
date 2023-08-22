using AutoMapper;
using StepUpApi.Data;
using StepUpApi.DTOs.User;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;
using System.Security.Cryptography;

namespace StepUpApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<User>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<User>>();
            serviceResponse.Data = _context.Users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> RegisterUser(CreateUserDto userDto)
        {
            var serviceResponse = new ServiceResponse<User>();
            if (userDto == null)
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }

            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = new User();
            newUser.Name = userDto.Name;
            newUser.UserName = userDto.UserName;
            newUser.PasswordHash = passwordHash; newUser.PasswordSalt = passwordSalt;
            _context.Users.Add(newUser);
            _context.SaveChanges();

            serviceResponse.Data = newUser;

            return serviceResponse;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
