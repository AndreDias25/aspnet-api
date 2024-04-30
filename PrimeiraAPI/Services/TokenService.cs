﻿using Microsoft.IdentityModel.Tokens;
using PrimeiraAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrimeiraAPI.Services
{
    public class TokenService
    {
        public static object GenerateToken(Employee employee)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("employeeId", employee.id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenConfig);

            var tokenString = tokenHandler.WriteToken(token);
            return new
            {
                token = tokenString
            };
        }
    }
}
