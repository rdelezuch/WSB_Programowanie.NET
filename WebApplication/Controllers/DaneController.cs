using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DaneController : Controller
    {
        public IActionResult Index()
        {
            var model = new DaneModel();
            model.Imie = "Robert";
            model.Nazwisko = "Deleżuch";
            return View(model);
        }
    }
}
