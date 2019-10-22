using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppFootball.Models;

namespace WebAppFootball.Controllers
{
    public class CoachController: Controller
    {
        CoachRepository coachRepository = new CoachRepository();
        public IActionResult Index()
        {
            return View(coachRepository.GetCoaches());
        }
        public IActionResult CreateCoach()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCoach(Coach obj)
        {
            coachRepository.AddCoach(obj);
            return RedirectToAction("index");
        }
        public IActionResult DeleteCoach(int[] id)
        {
            coachRepository.DeleteCoach(id);
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Coach obj = coachRepository.GetCoachById(id);
            //coachRepository.EditCoach(obj);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Coach obj)
        {
            coachRepository.EditCoach(obj);
            return RedirectToAction("index");
        }
        public IActionResult all(int[] d)
        {
            //foreach (var id in d)
            //{
            //    coachRepository.DeleteCoach(id);
            //}
            coachRepository.DeleteCoach(d);
            //coachRepository.DeleteCoaches(d);
            return RedirectToAction("index");
        }
        public IActionResult Search(string q)
        {
            return View(coachRepository.Search(q));
        }
    }
}
