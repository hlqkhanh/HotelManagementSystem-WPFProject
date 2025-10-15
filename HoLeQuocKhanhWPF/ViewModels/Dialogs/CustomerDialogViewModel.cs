using BLL.IServices;
using BLL.Services;
using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HoLeQuocKhanhWPF.ViewModels.Dialogs
{
    public class CustomerDialogViewModel : ViewModelBase
    {
        private readonly ICustomerService _customerService;
        private Customer _customer;
        private bool _isEditMode;

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public CustomerDialogViewModel(Customer customer = null)
        {
            _customerService = new CustomerService();
            _isEditMode = customer != null;
            Customer = customer ?? new Customer();
            SaveCommand = new RelayCommand<Window>(Save);
        }

        private void Save(Window window)
        {
            if (_isEditMode)
            {
                _customerService.UpdateCustomer(Customer);
            }
            else
            {
                _customerService.AddCustomer(Customer);
            }
            window.DialogResult = true;
            window.Close();
        }
    }
}
