using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer;
using HotelManagerV2._0.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerV2._0.Controllers
{
    public class ContactController : Controller
    {
        private readonly HotelContext _context;
        public ContactController(HotelContext context)
        {
            _context = context;
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(QuestionBindingModel model)
        {
            QuestionSender sender = new QuestionSender()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                City = model.City,
                State = model.State,
                Zip = model.Zip
            };
            Question question = new Question()
            {
                Subject = model.Subject,
                QuestionAsked = model.QuestionAsked
            };
            await _context.Questions.AddAsync(question);
            await _context.QuestionSenders.AddAsync(sender);
            await _context.SaveChangesAsync();

            return View("Views/Contact/Contact.cshtml");
        }
    }
}