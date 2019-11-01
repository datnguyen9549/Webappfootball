using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppFootball.Models;

namespace WebAppFootball.Controllers
{
    public class PlayerController : BaseController
    {
        AppReposiroty app = new AppReposiroty();
        public IActionResult Index(int id=1)
        {
            int page;
            List<Player> list = app.Player.GetPlayers(id, 100, out page);
            ViewBag.page = page;
            return View(list);
        }
        public IActionResult Delete(int id)
        {
            app.Player.Delete(id);
            return RedirectToAction("index");
        }
        public IActionResult Create()
        {
            // Vi viewbag ben View model can tra ve list neen su dung Selectlist()
            // "Id" la value, "Name" la data text.
            ViewBag.Positions = new SelectList(app.Position.GetPosition(),"Id","Name");
            ViewBag.Countries = new SelectList(app.Country.GetCountries(),"Id","Name");
            ViewBag.Clubs = new SelectList(app.Club.GetClubs(), "Id", "Name");
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.countries = new SelectList(app.Country.GetCountries(),"Id","Name");
            ViewBag.positions = new SelectList(app.Position.GetPosition(), "Id", "Name");
            ViewBag.clubs = new SelectList(app.Club.GetClubs(), "Id", "Name");
            return View(app.Player.GetPlayerById(id));
        }
        public IActionResult Search(string q, int id = 1)
        {
            int page;
            List<Player> list = app.Player.SearchPlayers(q,id, 10, out page);
            ViewBag.page = page;
            return View(list);
        }
        [HttpPost]
        public IActionResult Edit(Player obj)
        {
            app.Player.Edit(obj);
            return RedirectToAction("index");

        }
        [HttpPost]
        public IActionResult Create(Player obj)
        {
            app.Player.Add(obj);
            return RedirectToAction("Index");
        }
    }
}