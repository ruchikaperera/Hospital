using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Modules.Doctors_Profile.Controllers
{
    public class DoctorsProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}