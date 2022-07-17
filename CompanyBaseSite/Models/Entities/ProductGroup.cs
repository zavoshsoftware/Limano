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
    public class ProductGroup:BaseEntity
    {
       
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public int Order { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Title { get; set; }

        public bool HasSeoEffect { get; set; }


        [Display(Name = "پارامتر url")]
        public string UrlParam { get; set; }

        [Display(Name = "تصویر")]
        public string ImageUrl { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Column(TypeName = "ntext")]
        [UIHint("RichText")]
        public string Body { get; set; }
 
        public virtual ICollection<Product> Products { get; set; }



        [Display(Name = "تگ Title")]
        public string PageTitle { get; set; }
        [Display(Name = "تگ meta description")]
        public string MetaDescription { get; set; }
    }
}