using Microsoft.IdentityModel.Tokens;
using StudentManagement.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using StudentManagement;
using MySql.Data.MySqlClient;
using StudentManagement.Repository;
using System.Data;
using StudentManagement.Operations.Interface;
using StudentManagement.Repository.Interface;

namespace StudentManagement.Authentication
{
    public class JWTAuth
    {
        private readonly string key;        
        public JWTAuth(string key)
        {
            this.key = key;
        }
        public string? Authenticate(string username, string password)
        {

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
                new Claim(ClaimTypes.Name, username)
              }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}









