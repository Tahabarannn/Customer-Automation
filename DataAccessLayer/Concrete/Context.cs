using System;
using EntityLayer.Concrete;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Affiliate> Affiliates { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<IsActive> IsActives { get; set; }
        public DbSet<ProfileImage> ProfileImages { get; set; }
    }
}
