using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppFootball.Models;

namespace WebAppFootball.Controllers
{
    public class BaseController : Controller
    {
        protected AppReposiroty appReposiroty = new AppReposiroty();

        static protected string Upload(IFormFile f)
        {
            if(f != null)
            {
                string path = Directory.GetCurrentDirectory() + "/wwwroot/images";
                using (Stream stream = System.IO.File.Create(path + f.FileName))
                {
                    f.CopyTo(stream);
                }
                return f.FileName;
            }
            return null;
        }
    }
}