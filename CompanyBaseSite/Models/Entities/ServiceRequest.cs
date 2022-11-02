using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Helpers;

namespace Models
{
    public class ServiceRequest : BaseEntity
    {
        [Display(Name="نام و نام خانوادگی")]
        public string FullName { get; set; }
        [Display(Name="شماره تماس")]
        public string CellNumber { get; set; } 
        [Display(Name="نوع خدمت")]
        public Guid? ServiceId { get; set; }
        public virtual Service Service { get; set; }
        [Display(Name="توضیحات")]
        public string Body { get; set; }
    }
}