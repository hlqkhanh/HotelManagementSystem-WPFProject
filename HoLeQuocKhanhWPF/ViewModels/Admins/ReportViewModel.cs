using BLL.IServices;
using BLL.Services;
using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace HoLeQuocKhanhWPF.ViewModels.Admins
{
    public class ReportViewModel : ViewModelBase
    {
        private readonly IBookingReservationService _bookingService;
        private DateTime _startDate = DateTime.Now.AddMonths(-1);
        private DateTime _endDate = DateTime.Now;
        private ObservableCollection<BookingReservation> _reportData;

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BookingReservation> ReportData
        {
            get => _reportData;
            set
            {
                _reportData = value;
                OnPropertyChanged();
            }
        }

        public ICommand GenerateReportCommand { get; }

        public ReportViewModel()
        {
            _bookingService = new BookingReservationService();
            GenerateReportCommand = new RelayCommand<object>(p => GenerateReport());
            GenerateReport(); // Initial report
        }

        private void GenerateReport()
        {
            if (StartDate > EndDate)
            {
                MessageBox.Show("Start date cannot be after end date.", "Invalid Date Range", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var allBookings = _bookingService.GetAllBookingReservation();
            var filteredBookings = allBookings
                .Where(b => b.BookingDate.HasValue &&
                            b.BookingDate.Value.Date >= StartDate.Date &&
                            b.BookingDate.Value.Date <= EndDate.Date)
                .OrderByDescending(b => b.BookingDate)
                .ToList();

            ReportData = new ObservableCollection<BookingReservation>(filteredBookings);
        }
    }
}