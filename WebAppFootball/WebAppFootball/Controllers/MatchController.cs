using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppFootball.Models;

namespace WebAppFootball.Controllers
{
    public class MatchController : BaseController
    {
        AppReposiroty app = new AppReposiroty();
        public IActionResult Index()
        {
            return View(app.Match.GetMatches());
        }
        public IActionResult show()
        {
            return View(app.Match.GetMatches());
        }
        public IActionResult show2()
        {
            List<Match> list = app.Match.GetMatches();
            List<Match>[] a = new List<Match>[38];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new List<Match>();
            }
            foreach (Match item in list)
            {
                a[item.Round - 1].Add(item);
            }
            return View(a);
        }
        public IActionResult show3()
        {
            return View(app.Match.GetMatches2());
        }
    }
}