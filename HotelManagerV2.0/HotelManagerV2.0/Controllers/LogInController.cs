using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer;
using HotelManagerV2._0.Models.BindingModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HotelManagerV2._0.Controllers
{
    public class LogInController : Controller
    {
        private readonly SignInManager<Worker> _signInManager;
        private readonly UserManager<Worker> _userManager;
        private readonly IConfiguration _config;
        private readonly HotelContext _context;

        public LogInController(SignInManager<Worker> sim, UserManager<Worker> um, IConfiguration config, HotelContext context) 
        {
            _signInManager = sim;
            _userManager = um;
            _config = config;
            _context = context; 
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(WorkerBindingModel model)
        {
            Worker accountFound = await _userManager.FindByNameAsync(model.Username);

            if (accountFound != null)
            {
                var isPasswordCorrect = await _signInManager.UserManager.CheckPasswordAsync(accountFound, model.Password);

                if (isPasswordCorrect == true)
                {
                    await _signInManager.SignInAsync(accountFound, isPersistent: true);
                    return RedirectToAction("Index", "Home");
                    //Ok(new
                    //{
                    //    result = result,
                    //    token = JwtTokenGeneratorMachine(user)
                    //});
                }
            }
            
            return BadRequest(accountFound);                  
        }

        private async Task<string> JwtTokenGeneratorMachine(Worker worker)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, worker.Id),
                new Claim(ClaimTypes.Name, worker.UserName)
            };

            var roles = await _userManager.GetRolesAsync(worker);

            foreach (var role in roles)
            {
                claims.Add(new Claim(type: ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8
             .GetBytes(_config.GetSection("AppSettings:Key").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Register(WorkerBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Worker user = new Worker()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                IdentityNumber = model.IdentityNumber,
                DateOfAppointment = DateTime.Now   
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (model.IsAdmin)
            {
                await _userManager.AddToRoleAsync(user, "admin");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "regularUser");
            }

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
            }
            return View("Views/Contact/Contact.cshtml");  
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}