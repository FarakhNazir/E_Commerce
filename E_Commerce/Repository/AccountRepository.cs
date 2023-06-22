using E_Commerce.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly  UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }



        public async Task<IdentityResult> SignUp( SignUpModel signUpModel)
        {
            var obj = new ApplicationUser()
            {
               FullName = signUpModel.FullName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email,
                PhoneNumber= signUpModel.PhoneNumber


            };

           return await _userManager.CreateAsync(obj, signUpModel.Password);
        }

        public async Task<string> Login(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
            if (!result.Succeeded) { return null; }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInModel.Email),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            
            var authSigingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials:new SigningCredentials(authSigingKey, SecurityAlgorithms.HmacSha256Signature)
                
                
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task SignOut() => await _signInManager.SignOutAsync();
    }
}
