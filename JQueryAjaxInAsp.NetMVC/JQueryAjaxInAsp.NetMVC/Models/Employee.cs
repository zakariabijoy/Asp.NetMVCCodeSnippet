using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JQueryAjaxInAsp.NetMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string  Office { get; set; }
        public int? Salary { get; set; }
        public string ImagePath { get; set; }
    }
}