using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerV2._0.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Rooms()
        {
            return View();
        }
    }
}