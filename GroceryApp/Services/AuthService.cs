using GroceryApp.Data;
using GroceryApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using System;
public class AuthService
{
    private readonly IConfiguration _config;
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context, IConfiguration config)
    {
        _config = config;
        _context = context;
    }
    public string Login(LoginRequestDto dto)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == dto.Username);

            if (user == null)
                return null;

            if (user.Password != dto.Password)
                return null;

            return GenerateToken(user.Username, user.Role);
        }

    public string GenerateToken(string username, string role)
    {
        var jwt = _config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwt["Key"])
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
