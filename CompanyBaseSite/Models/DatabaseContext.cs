using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Models
{
   public class DatabaseContext:DbContext
    {
        static DatabaseContext()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Migrations.Configuration>());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogGroup> BlogGroups { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<TextItem> TextItems { get; set; }
        public DbSet<ContactUsForm> ContactUsForms { get; set; }
        public DbSet<TextItemType> TextItemTypes { get; set; }

        public System.Data.Entity.DbSet<Models.ProductGroup> ProductGroups { get; set; }

        public System.Data.Entity.DbSet<Models.Product> Products { get; set; }
        public System.Data.Entity.DbSet<Models.ServiceRequest> ServiceRequests { get; set; }
        public System.Data.Entity.DbSet<Models.ServiceImage> ServiceImages { get; set; }
        public System.Data.Entity.DbSet<Models.Service> Services { get; set; }
        public System.Data.Entity.DbSet<Models.GalleryItem> GalleryItems { get; set; }
        public System.Data.Entity.DbSet<Models.GalleryItemGroup> GalleryItemGroups { get; set; }
        public System.Data.Entity.DbSet<Models.Team> Teams { get; set; }
    }
}
