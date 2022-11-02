using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Helpers;

namespace Models
{
    public class ServiceImage : BaseEntity
    {
        [Display(Name="اولویت نمایش")]
        public int Order { get; set; }
        [Display(Name="عنوان تصویر")]
        public string Title { get; set; } 
        [Display(Name="نوع خدمت")]
        public Guid? ServiceId { get; set; }
        public virtual Service Service { get; set; }
        [Display(Name="تصویر")]
        public string ImageUrl { get; set; }
    }
}