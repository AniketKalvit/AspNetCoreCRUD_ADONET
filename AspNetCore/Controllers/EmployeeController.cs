using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeDAL db;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new EmployeeDAL(configuration);
        }
        public IActionResult List()
        {
            var model = db.GetAllEmployees();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            try
            {
                int res=db.AddEmployee(emp);
                if (res == 1)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View();
            }
            
        }
    }
}
