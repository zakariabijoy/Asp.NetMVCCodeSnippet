 using JQueryAjaxInAsp.NetMVC.Models;
using System;
using System.Collections.Generic;
 using System.Data.Entity;
 using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 using System.Web.Services.Description;

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
           
            return View(GetAllEmployee());
        }

        IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList<Employee>();
        }

        public ActionResult AddOrEdit(int id =0)
        {
            Employee emp = new Employee();
            if (id != 0)
            {
                emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            }
            return View(emp);
        }

        [HttpPost]
       public ActionResult AddOrEdit(Employee emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string fileExtention = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtention;

                    emp.ImagePath = "~/AppFiles/Images/" + fileName;

                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));

                }

                if (emp.Id == 0)
                {
                    _context.Employees.Add(emp);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Entry(emp).State = EntityState.Modified;
                    _context.SaveChanges();
                }
               

                return Json(new
                {
                    success = true,
                    html = GlobalClass.RenderRazorViewToString(this, "ViewAll",
                    GetAllEmployee()),
                    message = "Submitted Successfully"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    success = false,
                    
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

       public ActionResult Delete(int id)
       {
           try
           {
               var emp = _context.Employees.Find(id);
               _context.Employees.Remove(emp);
               _context.SaveChanges();

               return Json(new
               {
                   success = true,
                   html = GlobalClass.RenderRazorViewToString(this, "ViewAll",
                       GetAllEmployee()),
                   message = "Deleted Successfully"
               }, JsonRequestBehavior.AllowGet);
            }
           catch (Exception ex)
           {
               return Json(new
               {
                   success = false,

                   message = ex.Message
               }, JsonRequestBehavior.AllowGet);
            }
          
       }
    }
}