using BLL.IServices;
using BLL.Services;
using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace HoLeQuocKhanhWPF.ViewModels.Customers
{
    public class CustomerProfileViewModel : ViewModelBase
    {
        private readonly ICustomerService _customerService;
        private Customer _currentCustomer;

        public Customer CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveChangesCommand { get; }

        public CustomerProfileViewModel(Customer customer)
        {
            _customerService = new CustomerService();
            CurrentCustomer = customer;

            SaveChangesCommand = new RelayCommand<object>(p => SaveChanges());
        }

        private void SaveChanges()
        {
            try
            {
                _customerService.UpdateCustomer(CurrentCustomer);
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}