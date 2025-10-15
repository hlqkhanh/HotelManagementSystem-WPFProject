using HoLeQuocKhanhWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public AdminMainViewModel()
        {
            ShowCustomerManagementCommand = new RelayCommand<object>(p => CurrentViewModel = new CustomerManagementViewModel());
            ShowRoomManagementCommand = new RelayCommand<object>(p => CurrentViewModel = new RoomManagementViewModel());
            ShowReportCommand = new RelayCommand<object>(p => CurrentViewModel = new ReportViewModel());

            // Default view
            CurrentViewModel = new CustomerManagementViewModel();
        }
    }
}
