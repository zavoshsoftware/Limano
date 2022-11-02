using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Models
{
    public class Service : BaseEntity
    {
        public Service()
        {
            ServiceRequests = new List<ServiceRequest>();
            ServiceImages = new List<ServiceImage>();
        }
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "پارامتر صفحه")]
        public string UrlParam { get; set; }

        [Display(Name = "تصویر شاخص")]
        public string ImageUrl { get; set; }
         
        [Display(Name = "خلاصه")]
        [DataType(DataType.MultilineText)]
        public string Summery { get; set; }
        [Display(Name = "متن صفحه")]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Column(TypeName = "ntext")]
        [UIHint("RichText")]
        public string Body { get; set; }

        [Display(Name = "اولویت نمایش")]
        public int? Order { get; set; }

        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
        public virtual ICollection<ServiceImage> ServiceImages { get; set; }
    }
}