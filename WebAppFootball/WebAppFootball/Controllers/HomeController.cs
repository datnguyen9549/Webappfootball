using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppFootball.Models;

namespace WebAppFootball.Controllers
{
    public class HomeController: Controller
    {
        CoachRepository repository = new CoachRepository();
        public IActionResult Index()
        {
            List<Coach> list = repository.GetCoaches();
            return View(list);
        }
    }
}
