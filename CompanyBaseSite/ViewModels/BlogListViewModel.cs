﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace CompanyBaseSite.ViewModels
{
    public class BlogListViewModel : _BaseViewModel
    {
        public List<Blog> Blogs { get; set; }
    }
}