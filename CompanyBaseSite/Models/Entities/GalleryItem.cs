using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class GalleryItem : BaseEntity
    {
       
        [Display(Name="عنوان تصویر")]
        public string Title { get; set; }

        [Display(Name="تصویر")]
        public string ImageUrl { get; set; }

        [Display(Name="دسته بندی")]
        public Guid GalleryItemGroupId { get; set; }
        public virtual GalleryItemGroup GalleryItemGroup { get; set; }


    }
}