// Trong thư mục /ViewModels/LoginViewModel.cs
using HoLeQuocKhanhWPF;
using HoLeQuocKhanhWPF.Commands;
using HoLeQuocKhanhWPF.Views;
using System.Security;
using System.Windows.Input;
// Giả sử bạn có các services này từ BLL
// using BusinessLogicLayer.Services; 

namespace HoLeQuocKhanhWPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email = string.Empty;
        private string _errorMessage = string.Empty;

        // private readonly IAuthService _authService; // Inject service từ BLL

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            // Trong dự án thật, bạn sẽ inject service qua constructor
            // _authService = new AuthService(); 

            LoginCommand = new RelayCommand(ExecuteLogin, CanLogin);
        }

        private bool CanLogin(object? parameter)
        {
            // Thêm logic validation nếu cần
            return !string.IsNullOrWhiteSpace(Email) && parameter is System.Windows.Controls.PasswordBox passBox && !string.IsNullOrEmpty(passBox.Password);
        }

        private void ExecuteLogin(object? parameter)
        {
            if (parameter is System.Windows.Controls.PasswordBox passBox)
            {
                string password = passBox.Password;

                // --- LOGIC GIẢ LẬP ---
                // Thay thế bằng logic gọi service từ BLL của bạn
                if (Email.Equals("admin@FUMiniHotelSystem.com") && password.Equals("@@abc123@@")) // Chú ý: password trong file JSON là "@@ abc123@ @"
                {
                    ErrorMessage = "";
                    // Mở màn hình Admin
                    AdminMainView adminView = new AdminMainView();
                    adminView.Show();
                    CloseWindow();
                }
                // else if (_authService.ValidateCustomer(Email, password))
                // {
                //     ErrorMessage = "";
                //     // Lấy thông tin customer và mở màn hình Customer
                //     var customer = _authService.GetCustomerByEmail(Email);
                //     CustomerMainView customerView = new CustomerMainView(customer);
                //     customerView.Show();
                //     CloseWindow();
                // }
                else
                {
                    ErrorMessage = "Invalid email or password.";
                }
            }
        }

        private void CloseWindow()
        {
            // Logic để đóng cửa sổ Login
            App.Current.Windows[0]?.Close();
        }
    }
}