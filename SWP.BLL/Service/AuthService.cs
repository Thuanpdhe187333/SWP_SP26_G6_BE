using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SWP.BLL.DTOs.Auth;
using SWP.BLL.IService;
using SWP.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWP.BLL.Service
{
    public class AuthService : IAuthService
    {
        private readonly HrmSystemContext _context;
        private readonly IConfiguration _config;

        public AuthService(HrmSystemContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public LoginResponseDto Login(LoginRequestDto request)
        {
            var user = _context.Users
                .AsNoTracking()
                .FirstOrDefault(u =>
                    u.Email == request.Email &&
                    u.Status == "Active");

            if (user == null)
                throw new Exception("Email hoặc mật khẩu không đúng");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Email hoặc mật khẩu không đúng");

            var token = GenerateJwt(user);

            return new LoginResponseDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                Token = token
            };
        }

        private string GenerateJwt(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var jwtKey = _config["Jwt:Key"]
                ?? throw new Exception("JWT Key is missing");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
