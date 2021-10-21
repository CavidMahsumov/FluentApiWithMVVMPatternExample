using ProjectWithMvvm.Commands;
using ProjectWithMvvm.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithMvvm.Domain.ViewModels
{
   public class MainViewModel:BaseViewModel
    {
        public RelayCommand SelectCustomerCommand { get; set; }
        public MainViewModel()
        {
            AllCustomers = App.DB.CustomerRepository.GetAllData();
            AllOrders = App.DB.OrderRepository.GetAllData();

            SelectCustomerCommand = new RelayCommand((sender) =>
              {
                  AllOrders = new ObservableCollection<Order>(SelectedCustomer.Orders);
              });
        }

        private ObservableCollection<Customer> allCustomers;

        public ObservableCollection<Customer> AllCustomers
        {
            get { return allCustomers; }
            set { allCustomers = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Order> allOrders;

        public ObservableCollection<Order> AllOrders
        {
            get { return allOrders; }
            set { allOrders = value; OnPropertyChanged(); }
        }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set { selectedCustomer = value; OnPropertyChanged(); }
        }


    }
}
