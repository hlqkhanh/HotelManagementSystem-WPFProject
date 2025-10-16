using BLL.IServices;
using BLL.Services;
using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace HoLeQuocKhanhWPF.ViewModels.Dialogs
{
    public class BookingDetailDialogViewModel : ViewModelBase
    {
        private readonly IBookingDetailService _bookingDetailService;
        private ObservableCollection<BookingDetail> _bookingDetails;

        public ObservableCollection<BookingDetail> BookingDetails
        {
            get => _bookingDetails;
            set
            {
                _bookingDetails = value;
                OnPropertyChanged();
            }
        }

        public BookingDetailDialogViewModel(BookingReservation reservation)
        {
            _bookingDetailService = new BookingDetailService();
            LoadBookingDetails(reservation.BookingReservationID);
        }

        private void LoadBookingDetails(int reservationId)
        {
            // Lấy tất cả chi tiết và lọc theo ID của đơn đặt phòng
            var allDetails = _bookingDetailService.GetBookingDetailList();
            if (allDetails != null)
            {
                var detailsForReservation = allDetails.Where(d => d.BookingReservationID == reservationId).ToList();
                BookingDetails = new ObservableCollection<BookingDetail>(detailsForReservation);
            }
            else
            {
                BookingDetails = new ObservableCollection<BookingDetail>();
            }
        }
    }
}