using Burak.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burak.Eticaret.Core.Model
{
    public class BurakDB : DbContext
    {
        //tablolar

        public BurakDB()
            :base(@"Data Source=DESKTOP-3K9BSP7;Initial Catalog=BurakEticaretDB;Integrated Security=True")

        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdress> Adresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProduts { get; set; }

        public DbSet<OrderPayment> OrderPayments { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

        }



    }
}
