using BLL.IServices;
using BLL.Services;
using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Base;
using System.Collections.ObjectModel;

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
            set
            {
                _bookingHistory = value;
                OnPropertyChanged();
            }
        }

        public BookingHistoryViewModel(Customer customer)
        {
            _bookingReservationService = new BookingReservationService();
            _currentCustomer = customer;
            LoadBookingHistory();
        }

        private void LoadBookingHistory()
        {
            var history = _bookingReservationService.GetBookingReservationsByCustomerID(_currentCustomer.CustomerID);
            BookingHistory = new ObservableCollection<BookingReservation>(history);
        }
    }
}