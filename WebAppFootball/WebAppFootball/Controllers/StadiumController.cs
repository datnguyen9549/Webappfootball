using Microsoft.AspNetCore.Mvc;
using WebAppFootball.Models;

namespace WebAppFootball.Controllers
{
    public class StadiumController:Controller
    {
        StadiumRepository stadiumRepository = new StadiumRepository();
        public IActionResult Index()
        {
            return View(stadiumRepository.GetStadium());
        }
        //Hien thi form
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Stadium obj)
        {
            stadiumRepository.Add(obj);
            return RedirectToAction("index");
        }
        public IActionResult delete(int id)
        {
            stadiumRepository.delete(id);
            return RedirectToAction("index");
        }
    }
}
