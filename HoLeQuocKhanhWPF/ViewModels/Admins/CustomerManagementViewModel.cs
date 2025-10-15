using BLL.IServices;
using BLL.Services;
using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Base;
using HoLeQuocKhanhWPF.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HoLeQuocKhanhWPF.ViewModels.Admins
{
    public class CustomerManagementViewModel : ViewModelBase
    {
        private readonly ICustomerService _customerService;
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;
        private string _searchText;

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCustomerCommand { get; }
        public ICommand EditCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand SearchCommand { get; }

        public CustomerManagementViewModel()
        {
            _customerService = new CustomerService();
            LoadCustomers();

            AddCustomerCommand = new RelayCommand<object>(p => AddCustomer());
            EditCustomerCommand = new RelayCommand<Customer>(EditCustomer);
            DeleteCustomerCommand = new RelayCommand<Customer>(DeleteCustomer);
            SearchCommand = new RelayCommand<object>(p => Search());
        }

        private void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(_customerService.GetAllCustomer());
        }

        private void AddCustomer()
        {
            var dialog = new CustomerDialog();
            if (dialog.ShowDialog() == true)
            {
                LoadCustomers();
            }
        }

        private void EditCustomer(Customer customer)
        {
            if (customer != null)
            {
                var dialog = new CustomerDialog(customer);
                if (dialog.ShowDialog() == true)
                {
                    LoadCustomers();
                }
            }
        }

        private void DeleteCustomer(Customer customer)
        {
            if (customer != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _customerService.DeleteCustomer(customer);
                    LoadCustomers();
                }
            }
        }

        private void Search()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadCustomers();
            }
            else
            {
                Customers = new ObservableCollection<Customer>(_customerService.GetAllCustomer().Where(c => c.CustomerFullName.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase)));
            }
        }
    }
}
