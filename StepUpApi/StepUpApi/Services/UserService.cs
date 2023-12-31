﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StepUpApi.Data;
using StepUpApi.DTOs.UserDto;
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
            var serviceResponse = new ServiceResponse<IEnumerable<User>>
            {
                Data = await _context.Users
                    .Include(u => u.Roles)
                    .ToListAsync()
            };
            return serviceResponse;
        }
        
        public async Task<ServiceResponse<IEnumerable<User>>> GetNotDeleted()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<User>>
            {
                Data = await _context.Users
                    .Include(u => u.Roles)
                    .Where(t => t.IsDeleted == false)
                    .ToListAsync()
            };
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
            await _context.SaveChangesAsync();

            serviceResponse.Data = newUser;

            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> Login(LoginUserDto userDto)
        {
            var serviceResponse = new ServiceResponse<string>();

            var user = await _context.Users
                .Include(user => user.Roles)
                .FirstOrDefaultAsync(u =>  u.UserName == userDto.UserName);

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
        
        public async Task<ServiceResponse<User>> GetById(Guid id)
        {
            var serviceResponse = new ServiceResponse<User>();
            serviceResponse.Data = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> Delete(Guid id)
        {
            var serviceResponse = await GetById(id);
            if (serviceResponse.Data == null)
            {
                serviceResponse.Message = "No user found";
                serviceResponse.Success = false;
                return serviceResponse;
            };

            var user = serviceResponse.Data;
            user.IsDeleted = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return serviceResponse;
        }

        #region
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
            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Type)));

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                issuer: _configuration.GetSection("AppSettings:Issuer").Value,
                audience: _configuration.GetSection("AppSettings:Audience").Value,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        #endregion

    }
}
