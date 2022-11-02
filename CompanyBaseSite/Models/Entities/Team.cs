using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Models
{
    public class Team : BaseEntity
    {
        [Display(Name="اولویت نمایش")]
        public int Order { get; set; }
       
        [Display(Name="نام")]
        public string FullName { get; set; }

        [Display(Name="مهارت")]
        public string Skill { get; set; }

        [Display(Name="تصویر")]
        public string ImageUrl { get; set; }

        [Display(Name= "Instagram")]
        public string Instagram { get; set; }
        [Display(Name= "Twitter")]
        public string Twitter { get; set; }
 
         
    }
}