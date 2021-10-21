using ProjectWithMvvm.Contexts;
using ProjectWithMvvm.Domain.Abstractions;
using ProjectWithMvvm.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithMvvm.DataAccess.EFrameworkServer
{
    public class EfOrderRepository : IOrderRepository
    {
        public void AddData(Order data)
        {
            using (var context=new MyContext())
            {
                context.Orders.Add(data);
                context.SaveChanges();
            }
        }

        public void DeleteData(Order data)
        {
            using (var context = new MyContext())
            {
                context.Orders.Remove(data);
                context.SaveChanges();
            }
        }

        public ObservableCollection<Order> GetAllData()
        {
            using (var context = new MyContext())
            {
                return new ObservableCollection<Order>(context.Orders.Include("Customer"));
            }
        }

        public Order GetData(int id)
        {
            using (var context = new MyContext())
            {
                var data = context.Orders.FirstOrDefault(o => o.Id == id);
                return data;
            }
        }

        public void UpdateData(Order data)
        {
            using (var context = new MyContext())
            {
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
