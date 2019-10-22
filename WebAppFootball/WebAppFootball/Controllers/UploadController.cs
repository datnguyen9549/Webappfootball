using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppFootball.Controllers
{
    public class UploadController : Controller
    {
        //Action upload images throught URL
        public IActionResult FromUrl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FromUrl(string u)
        {
            if (!string.IsNullOrEmpty(u))
            {
                string filename = Path.GetFileName(u);
                string path = Directory.GetCurrentDirectory() + "/wwwroot/images/";
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(u, path + filename);
                }
                return RedirectToAction("fromurl");
            }
            return View();
        }
        //Action upload multiple file
        public IActionResult Multiple()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Multiple(IFormFile[] f)
        {
            string path = Directory.GetCurrentDirectory() + "/wwwroot/images/";
            foreach (IFormFile file in f)
            {
                using (Stream stream = System.IO.File.Create(path + file.FileName))
                {
                    file.CopyTo(stream);
                }
            }
            return RedirectToAction("Index");
        }
        //tao controller de upload file
        public IActionResult Index()
        {
            return View();
        }
        // su dung phuong thuc post de upload file
        [HttpPost]
        // Ten "f" phia cung name voi name cua form.
        public IActionResult Index(IFormFile f)
        {
            if(f != null)
            {
                string filename = f.FileName;
                string path = Directory.GetCurrentDirectory() + "/wwwroot/images/";
                using (Stream stream = System.IO.File.Create(path + filename))
                {
                    f.CopyTo(stream);
                }
                return RedirectToAction("index");
            }
            return View();
        }
    }

}