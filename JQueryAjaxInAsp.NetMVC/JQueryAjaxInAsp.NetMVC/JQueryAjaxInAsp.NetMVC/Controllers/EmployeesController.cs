using JQueryAjaxInAsp.NetMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQueryAjaxInAsp.NetMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
           var employees= _context.Employees.ToList();
            return View(employees);
        }

        public ActionResult AddOrEdit(int id =0)
        {
            Employee emp = new Employee();
            return View(emp);
        }

        [HttpPost]
       public ActionResult AddOrEdit(Employee emp)
        {
            if (emp.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                string fileExtention = Path.GetExtension(emp.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtention;

                emp.ImagePath = "~/AppFiles/Images/" + fileName;

                emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));

            }
            _context.Employees.Add(emp);
            _context.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("ViewAll");
        }
    }
}