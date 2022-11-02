using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace CompanyBaseSite.ViewModels
{
    public class HomeViewModel:_BaseViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<GalleryItemGroup> GalleryItemGroups { get; set; }
        public List<GalleryItem> GalleryItems { get; set; }
        public List<Team> Teams { get; set; }
        public List<Blog> HomeBlogs { get; set; }

    }
}