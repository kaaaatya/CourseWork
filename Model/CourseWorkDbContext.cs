using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CourseWorkDbContext : DbContext
    {
        public CourseWorkDbContext() : base("name=CourseWorkDbContext")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
           System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderProduct> ProviderProducts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestProduct> RequestProducts { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
