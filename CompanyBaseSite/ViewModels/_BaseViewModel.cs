using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers;
using Models;

namespace CompanyBaseSite.ViewModels
{
    public class _BaseViewModel
    {
        private BaseViewModelHelper helper = new BaseViewModelHelper();
        public List<Service> MenuServices
        {
            get
            {
                return helper.GetMenuService();
            }
        }
    }
}