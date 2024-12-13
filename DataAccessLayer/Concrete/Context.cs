using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DD\\SQLEXPRESS01;database=TraversalCoreDb;integrated security=true;TrustServerCertificate=True;");


        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutNext> AboutNexts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureSub> FeatureSub { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<AboutSub> AboutSub { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
