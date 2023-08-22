using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using StepUpApi.Data;
using StepUpApi.DTOs.User;
using StepUpApi.Models;
using StepUpApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace StepUpApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(ApiDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
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

        public async Task<ServiceResponse<string>> Login(LoginUserDto userDto)
        {
            var serviceResponse = new ServiceResponse<string>();

            var user = _context.Users.FirstOrDefault(u =>  u.UserName == userDto.UserName);

            if (user == null)
            {
                serviceResponse.Message = "Login denied";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            if(!VerifyPasswordHash(userDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                serviceResponse.Message = "Login denied";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            string Token = CreateToken(user);
            serviceResponse.Data = Token;
            return serviceResponse;
        }



        //-----------------------------------------------------------------------------------------------
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
