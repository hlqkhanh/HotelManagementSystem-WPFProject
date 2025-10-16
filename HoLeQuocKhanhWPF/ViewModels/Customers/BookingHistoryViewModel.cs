using BLL.IServices;
using BLL.Services;
using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Base;
using HoLeQuocKhanhWPF.Views.Dialogs; // Đảm bảo có using này
using System.Collections.ObjectModel;
using System.Windows.Input; // Đảm bảo có using này

namespace HoLeQuocKhanhWPF.ViewModels.Customers
{
    public class BookingHistoryViewModel : ViewModelBase
    {
        private readonly IBookingReservationService _bookingReservationService;
        private readonly Customer _currentCustomer;
        private ObservableCollection<BookingReservation> _bookingHistory;

        public ObservableCollection<BookingReservation> BookingHistory
        {
            get => _bookingHistory;
            set { _bookingHistory = value; OnPropertyChanged(); }
        }

        public ICommand ViewDetailCommand { get; }

        public BookingHistoryViewModel(Customer customer)
        {
            _bookingReservationService = new BookingReservationService();
            _currentCustomer = customer;
            LoadBookingHistory();

            // Khởi tạo Command nhận tham số là BookingReservation
            ViewDetailCommand = new RelayCommand<BookingReservation>(ViewDetail);
        }

        private void LoadBookingHistory()
        {
            var history = _bookingReservationService.GetBookingReservationsByCustomerID(_currentCustomer.CustomerID);
            if (history != null)
            {
                BookingHistory = new ObservableCollection<BookingReservation>(history);
            }
            else
            {
                BookingHistory = new ObservableCollection<BookingReservation>();
            }
        }

        // Phương thức xử lý đã được đơn giản hóa
        private void ViewDetail(BookingReservation reservation)
        {
            if (reservation != null)
            {
                var detailDialog = new BookingDetailDialog(reservation);
                detailDialog.ShowDialog();
            }
        }
    }
}