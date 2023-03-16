﻿using ApiWebshop.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiWebshop
{
    public class JwtAuthentificationService : InterfaceJwtAuthentificationService
    {
        private readonly List<Utilisateur> Utilisateurs = new List<Utilisateur>()
        {
            new Utilisateur
            {
                Id = 1,
                Username = "mickael",
                Email = "admin@gmail.com",
                Password = "Epsi2023",
            },
            new Utilisateur
            {
                Id = 2,
                Username = "fakri",
                Email = "admin1@gmail.com",
                Password = "Azerty2023",
            },
            new Utilisateur
            {
                Id = 3,
                Username = "wilson",
                Email = "admin2@gmail.com",
                Password = "Mspr2023",
            },
            new Utilisateur
            {
                Id = 4,
                Username = "dylan",
                Email = "admin3@gmail.com",
                Password = "School2023",
            }

        };

        internal static object ValidateToken(string? token, object value)
        {
            throw new NotImplementedException();
        }

        internal static Task<bool> VerifyToken(string token)
        {
            throw new NotImplementedException();
        }

        //Authentification de l'utilisateur
        public Utilisateur Authenticate(string email, string password)
        {
            return Utilisateurs.Where(u => u.Email.Equals(email) && u.Password.Equals(password)).FirstOrDefault();
        }

        public string GenerateToken(string secret, List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
