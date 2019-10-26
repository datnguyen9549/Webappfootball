using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppFootball.Models;

namespace WebAppFootball.Controllers
{
    public class PlayerController : BaseController
    {
        AppReposiroty app = new AppReposiroty();
        public IActionResult Index()
        {
            return View(app.Player.GetPlayers());
        }
    }
}