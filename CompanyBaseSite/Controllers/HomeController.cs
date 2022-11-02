using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyBaseSite.ViewModels;
using Models;

namespace CompanyBaseSite.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            HomeViewModel result = new HomeViewModel()
            {
                Sliders = db.Sliders.Where(c=>c.IsDeleted==false&&c.IsActive).OrderBy(c=>c.Order).ToList(),
                GalleryItemGroups     = db.GalleryItemGroups.Where(c=>c.IsDeleted==false&&c.IsActive).ToList(),
                GalleryItems = db.GalleryItems.Where(c=>c.IsDeleted==false&&c.IsActive).Take(6).ToList(),
                Teams = db.Teams.Where(c=>c.IsDeleted==false&&c.IsActive).OrderBy(c=>c.Order).ToList(),
                HomeBlogs = db.Blogs.Where(c=>c.IsDeleted==false&&c.IsActive).OrderByDescending(c=>c.CreationDate).Take(3).ToList(),
            };
            return View(result);
        }
  
        [Route("About")]
        [AllowAnonymous]
        public ActionResult About()
        {
            AboutViewModel result = new AboutViewModel()
            {
                Services = db.Services.Where(c => c.IsDeleted == false && c.IsActive).ToList()
            };
            return View(result);
        }
        [Route("Contact")]
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View(new _BaseViewModel());
        }

    }
}