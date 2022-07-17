using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;
using ViewModels;

//using ViewModels;

namespace Helpers
{
    public class BaseViewModelHelper
    {
        private DatabaseContext db = new DatabaseContext();

        //public List<Service> GetMenuService()
        //{
        //    List<Service> menuItems = db.Services.Where(c => c.IsDeleted == false && c.IsActive).ToList();
        //    return menuItems;
        //}

     

    }
}