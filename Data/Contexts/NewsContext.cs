using Core.Concretes.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Data.Contexts
{
    public class NewsContext : IdentityDbContext<IdentityUser>
    {
        public NewsContext() : base("name=default")
        {

        }

        // Singleton Design Pattern: Bir nesnenin bellekte oturum boyunca bir kez tanımlanmasını ve onun kullanılmasını sağlayan tasarım şablonudur. Performans ve güvenli kodlama için önemlidir, yığın taşması (stack overflow) hatalarının önüne geçer.
        private static NewsContext instance;
        public static NewsContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NewsContext();
                }
                return instance;
            }
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Member> Members { get; set; }
    }
}
