using AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<string> list = new List<string>();
            list.Add("Select an option");
            list.Add("Yes");
            list.Add("No");
            //ViewData["List"] = new SelectList(list,"Id","Name");
            ViewData["List"] = new SelectList(list);
            return View();
        }
        [HttpPost]
        [Route("Home")]
        public IActionResult Index(IFormCollection form, ICollection<string> hobbies)
        {
            ViewBag.Name = form["ename"];
            ViewBag.Gender = form["gender"];
            ViewBag.Option = form["List"];
            ViewBag.Hobbies = hobbies;
            return View("Display");
        }

        [HttpGet]
        public IActionResult Createproduct()
        {
            return View();
        }
        public  IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Createproduct(Product prod)
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            // Msg- key           value
            ViewData["Msg"] = "This is sample text msg";
            

            return View();
        }
    }
}
