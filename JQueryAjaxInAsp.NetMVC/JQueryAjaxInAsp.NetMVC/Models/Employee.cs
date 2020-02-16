﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JQueryAjaxInAsp.NetMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public int? Salary { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Employee()
        {
            ImagePath = "~/AppFiles/Images/default.png";
        }
    }
}