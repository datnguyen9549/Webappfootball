using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppFootball.Models;

namespace WebAppFootball.Controllers
{
    public class ClubController: BaseController
    {
        AppReposiroty app = new AppReposiroty();
        public IActionResult Index()
        {
            ViewBag.coaches = app.Coach.GetCoaches();
            ViewBag.stadiums = app.Stadium.GetStadium();
            return View(app.Club.GetClubs());
        }

        // Tao mot view Search
        // Input SearchClub object
        // return ve view, ket qua search cua menthod SearchClubs
        public IActionResult Search(SearchClub obj)
        {
            ViewBag.coaches = app.Coach.GetCoaches();
            ViewBag.stadiums = app.Stadium.GetStadium();
            return View(app.Club.SearchClubs(obj));
        }
        public IActionResult Create()
        {
            //su dung ViewBag khi muon them nhieu data vao view.
            ViewBag.stadiums = app.Stadium.GetStadium();
            ViewBag.coachs = app.Coach.GetCoaches();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Club obj, IFormFile f)
        {
            //if(f!= null)
            //{
            //    string path = Directory.GetCurrentDirectory() + "/wwwroot/images";
            //    using (Stream stream = System.IO.File.Create(path + f.FileName))
            //    {
            //        f.CopyTo(stream);
            //    }
            //    obj.LogoUrl = f.FileName;
            //}
            obj.LogoUrl = Upload(f);
            app.Club.Add(obj);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.stadiums = app.Stadium.GetStadium();
            ViewBag.coachs = app.Coach.GetCoaches();
            return View(app.Club.GetClubById(id));
        }
        [HttpPost]
        public IActionResult Edit(Club obj, IFormFile f)
        {
            //if (f != null)
            //{
            //    string path = Directory.GetCurrentDirectory() + "/wwwroot/images";
            //    using (Stream stream = System.IO.File.Create(path + f.FileName))
            //    {
            //        f.CopyTo(stream);
            //    }
            //    obj.LogoUrl = f.FileName;
            //}
            string filename = Upload(f);
            if(filename != null)
            {
                obj.LogoUrl = Upload(f);
            }
            app.Club.Edit(obj);
            return RedirectToAction("Index");
        }
    }
}
