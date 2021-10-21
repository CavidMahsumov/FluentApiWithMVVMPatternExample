using ProjectWithMvvm.Entities;
using ProjectWithMvvm.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithMvvm.Contexts
{
    public class MyContext:DbContext
    {
        public MyContext()
        {
            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
           
        }
    }
}
