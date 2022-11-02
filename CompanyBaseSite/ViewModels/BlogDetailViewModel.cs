using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace CompanyBaseSite.ViewModels
{
    public class BlogDetailViewModel : _BaseViewModel
    {
        public List<Blog> RelatedBlogs { get; set; }
        public Blog Blog { get; set; }
        public List<BlogComment> BlogComments { get; set; }
    }
}