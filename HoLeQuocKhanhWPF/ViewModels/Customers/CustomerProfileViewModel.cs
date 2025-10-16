using BLL.IServices;
using BLL.Services;
using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Base;
using HoLeQuocKhanhWPF.Views.Dialogs; // Thêm using cho thư mục Dialogs
using System.Windows;
using System.Windows.Input;

namespace HoLeQuocKhanhWPF.ViewModels.Customers
{
    public class CustomerProfileViewModel : ViewModelBase
    {
        private readonly ICustomerService _customerService;
        private BussinessObjects.Models.Customer _currentCustomer;

        public BussinessObjects.Models.Customer CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveChangesCommand { get; }
        public ICommand ChangePasswordCommand { get; } // Thêm Command mới

        public CustomerProfileViewModel(BussinessObjects.Models.Customer customer)
        {
            _customerService = new CustomerService();
            CurrentCustomer = customer;

            SaveChangesCommand = new RelayCommand<object>(p => SaveChanges());
            ChangePasswordCommand = new RelayCommand<object>(p => ChangePassword()); // Khởi tạo Command
        }

        private void SaveChanges()
        {
            try
            {
                // Logic lưu không còn liên quan đến mật khẩu
                _customerService.UpdateCustomer(CurrentCustomer);
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Phương thức mới để mở dialog đổi mật khẩu
        private void ChangePassword()
        {
            var changePasswordDialog = new ChangePasswordDialog(CurrentCustomer);
            changePasswordDialog.ShowDialog();
        }
    }
}