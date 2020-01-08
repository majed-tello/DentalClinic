using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicManagement.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Clinic()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }
    }
}