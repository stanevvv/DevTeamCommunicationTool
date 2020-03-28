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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HotelManagerV2._0.Controllers
{
    public class LogInController : Controller
    {
        private readonly HotelContext _context;
        private readonly UserStore<Worker> _us;
        private readonly SignInManager<Worker> _signInManager;
        private readonly UserManager<Worker> _userManager;
        private readonly IConfiguration _config;

        public LogInController(HotelContext context, SignInManager<Worker> sim, UserManager<Worker> um, IConfiguration config) 
        {
            _context = context;
            _signInManager = sim;
            _userManager = um;
            _config = config;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(WorkerBindingModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(new
            {
                result = result,
                token = JwtTokenGeneratorMachine(user)
            });
                       
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(WorkerBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    Worker user = new Worker()
        //    {
        //        FirstName = model.FirstName,
        //        MiddleName = model.MiddleName,
        //        LastName = model.LastName,
        //        UserName = model.Username,
        //        Email = model.Email,
        //        PhoneNumber = model.PhoneNumber,
        //        IdentityNumber = model.IdentityNumber,
        //        DateOfAppointment = DateTime.Now
        //    };
        //    var result = await _um.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        await _sim.SignInAsync(user, isPersistent: false);
        //    }

        //}
    }
}