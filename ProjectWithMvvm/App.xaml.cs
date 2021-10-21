using ProjectWithMvvm.Contexts;
using ProjectWithMvvm.DataAccess.EFrameworkServer;
using ProjectWithMvvm.Domain.Abstractions;
using ProjectWithMvvm.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectWithMvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;
        public App()
        {
            //creation db

            //using (var context = new MyContext())
            //{
            //    context.Database.CreateIfNotExists();
            //}
            DB = new EFUnitOfWork();
            if (DB.CustomerRepository.GetAllData().Count == 0)
            {
                var customer1 = new Customer
                {
                    City = "Baku",
                    CompanyName = "StepIT MMC",
                    ContactName = "213456789",
                    Country = "Azerbaijan"
                };
                var customer2 = new Customer
                {
                    City = "Ankara",
                    CompanyName = "Ankara MMC",
                    ContactName = "213456789",
                    Country = "Turkish"
                };

                DB.CustomerRepository.AddData(customer1);
                DB.CustomerRepository.AddData(customer2);


                var order1 = new Order
                {
                    CustomerId = 1,
                    OrderDate = DateTime.Now.AddDays(-3)
                };
                var order2 = new Order
                {
                    CustomerId = 1,
                    OrderDate = DateTime.Now.AddDays(-5)
                };
                var order3 = new Order
                {
                    CustomerId = 2,
                    OrderDate = DateTime.Now.AddDays(-10)
                };
                var order4 = new Order
                {
                    CustomerId = 1,
                    OrderDate = DateTime.Now
                };
                DB.OrderRepository.AddData(order1);
                DB.OrderRepository.AddData(order2);
                DB.OrderRepository.AddData(order3);
                DB.OrderRepository.AddData(order4);
            }
        }
    }
}
