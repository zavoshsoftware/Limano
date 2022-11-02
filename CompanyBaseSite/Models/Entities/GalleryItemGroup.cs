using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class GalleryItemGroup : BaseEntity
    {
        public GalleryItemGroup()
        {
            GalleryItems = new List<GalleryItem>();
        }
        [Display(Name="گروه تصاویر")]
        public string Title { get; set; }
       
        public virtual ICollection<GalleryItem> GalleryItems { get; set; }

    }
}