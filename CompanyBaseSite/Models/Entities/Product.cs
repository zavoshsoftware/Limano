using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Models
{
    public class Product:BaseEntity
    {
        [Display(Name = "اولویت نمایش")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public int Order { get; set; }

        [Display(Name = "کد محصول")]
        public int Code { get; set; }

        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Title { get; set; }

        [Display(Name = "تگ Title")]
        [StringLength(500, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string PageTitle { get; set; }

        [Display(Name = "تگ meta description")]
        [StringLength(1000, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        [DataType(DataType.MultilineText)]
        public string PageDescription { get; set; }

        [Display(Name = "تصویر")]
        [StringLength(500, ErrorMessage = "طول {0} نباید بیشتر از {1} باشد")]
        public string ImageUrl { get; set; }
           
        [Display(Name = "توضیحات خلاصه")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Column(TypeName = "ntext")]
        [UIHint("RichText")]
        public string Body { get; set; }
         
        [Display(Name = "گروه محصول")]
        public Guid ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
         
         
        [Display(Name = "بازدید")]
        public int Visit { get; set; }

      
    }
}