using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace CompanyBaseSite.ViewModels
{
    public class AboutViewModel:_BaseViewModel
    {
        public List<Service> Services { get; set; }
    }
}