using HoLeQuocKhanhWPF.ViewModels.Base;
using HoLeQuocKhanhWPF.Views; // Thêm using để trỏ tới LoginView
using System.Windows;         // Thêm using cho Window và Application
using System.Windows.Input;

namespace HoLeQuocKhanhWPF.ViewModels.Admins
{
    public class AdminMainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowCustomerManagementCommand { get; }
        public ICommand ShowRoomManagementCommand { get; }
        public ICommand ShowReportCommand { get; }
        public ICommand LogoutCommand { get; } // Thêm Command Logout

        public AdminMainViewModel()
        {
            ShowCustomerManagementCommand = new RelayCommand<object>(p => CurrentViewModel = new CustomerManagementViewModel());
            ShowRoomManagementCommand = new RelayCommand<object>(p => CurrentViewModel = new RoomManagementViewModel());
            ShowReportCommand = new RelayCommand<object>(p => CurrentViewModel = new ReportViewModel());

            // Khởi tạo LogoutCommand, nhận tham số là Window hiện tại
            LogoutCommand = new RelayCommand<Window>(Logout);

            // Default view
            CurrentViewModel = new CustomerManagementViewModel();
        }

        // Phương thức xử lý logic Logout
        private void Logout(Window window)
        {
            if (window != null)
            {
                var loginView = new LoginView();
                // Gán cửa sổ MainWindow của ứng dụng là LoginView mới
                Application.Current.MainWindow = loginView;
                loginView.Show();
                // Đóng cửa sổ Admin hiện tại
                window.Close();
            }
        }
    }
}