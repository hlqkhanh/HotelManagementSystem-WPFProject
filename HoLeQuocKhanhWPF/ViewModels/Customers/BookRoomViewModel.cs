using BLL.IServices;
using BLL.Services;
using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HoLeQuocKhanhWPF.ViewModels.Customers
{
    public class BookRoomViewModel : ViewModelBase
    {
        // Các services để tương tác với business logic layer
        private readonly IRoomInformationService _roomService;
        private readonly IBookingDetailService _bookingDetailService;
        private readonly IBookingReservationService _bookingReservationService;

        // Thông tin khách hàng đang đăng nhập
        private readonly Customer _currentCustomer;

        // Các thuộc tính binding với View
        private DateTime _startDate = DateTime.Now.Date;
        private DateTime _endDate = DateTime.Now.AddDays(1).Date;
        private ObservableCollection<RoomInformation> _availableRooms;

        public DateTime StartDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged(); }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set { _endDate = value; OnPropertyChanged(); }
        }

        public ObservableCollection<RoomInformation> AvailableRooms
        {
            get => _availableRooms;
            set { _availableRooms = value; OnPropertyChanged(); }
        }

        // Các Command binding với các nút bấm trên View
        public ICommand SearchCommand { get; }
        public ICommand BookCommand { get; }

        // Hàm khởi tạo của ViewModel
        public BookRoomViewModel(Customer customer)
        {
            _currentCustomer = customer;
            _roomService = new RoomInformationService();
            _bookingDetailService = new BookingDetailService();
            _bookingReservationService = new BookingReservationService();

            // Khởi tạo các Command
            SearchCommand = new RelayCommand<object>(p => SearchAvailableRooms());
            BookCommand = new RelayCommand<DataGrid>(BookRooms);

            // Tải danh sách phòng trống lần đầu tiên
            SearchAvailableRooms();
        }

        private void SearchAvailableRooms()
        {
            if (StartDate >= EndDate)
            {
                MessageBox.Show("End date must be after start date.", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var allRooms = _roomService.GetRoomInformationList();
            if (allRooms == null)
            {
                AvailableRooms = new ObservableCollection<RoomInformation>();
                return;
            }

            var allBookingDetails = _bookingDetailService.GetBookingDetailList() ?? new List<BookingDetail>();

            // Lấy danh sách ID của các phòng đã được đặt và có ngày trùng lặp
            var unavailableRoomIds = allBookingDetails
                .Where(detail => detail.StartDate < EndDate && detail.EndDate > StartDate)
                .Select(detail => detail.RoomID)
                .Distinct()
                .ToList();

            // Lọc ra danh sách các phòng còn trống
            var availableRoomsList = allRooms
                .Where(room => !unavailableRoomIds.Contains(room.RoomID))
                .ToList();

            AvailableRooms = new ObservableCollection<RoomInformation>(availableRoomsList);
        }

        private void BookRooms(DataGrid availableRoomsGrid)
        {
            if (availableRoomsGrid == null || availableRoomsGrid.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select one or more rooms to book.", "No Rooms Selected", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var selectedRooms = availableRoomsGrid.SelectedItems.Cast<RoomInformation>().ToList();
            string roomNumbers = string.Join(", ", selectedRooms.Select(r => r.RoomNumber));

            var result = MessageBox.Show($"Are you sure you want to book the following rooms from {StartDate:dd/MM/yyyy} to {EndDate:dd/MM/yyyy}?\n\nRooms: {roomNumbers}",
                                         "Confirm Booking", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    int numberOfDays = (EndDate - StartDate).Days;
                    decimal totalPrice = selectedRooms.Sum(room => numberOfDays * room.RoomPricePerDate);

                    var newReservation = new BookingReservation
                    {
                        BookingDate = DateTime.Now,
                        TotalPrice = totalPrice,
                        CustomerID = _currentCustomer.CustomerID,
                        BookingStatus = 1
                    };

                    // **QUAN TRỌNG**: Ở đây bạn cần gọi service để lưu `newReservation` vào CSDL
                    // và lấy ra ID của nó sau khi lưu thành công.
                    // Ví dụ: _bookingReservationService.AddBookingReservation(newReservation);

                    // Giả lập việc đã có ID mới sau khi lưu
                    int newReservationId = new Random().Next(100, 1000);

                    var newBookingDetails = new List<BookingDetail>();
                    foreach (var room in selectedRooms)
                    {
                        var newDetail = new BookingDetail
                        {
                            BookingReservationID = newReservationId,
                            RoomID = room.RoomID,
                            StartDate = StartDate,
                            EndDate = EndDate,
                            ActualPrice = room.RoomPricePerDate
                        };
                        newBookingDetails.Add(newDetail);
                    }

                    // **QUAN TRỌNG**: Ở đây bạn cần gọi service để lưu danh sách `newBookingDetails` vào CSDL.
                    // Ví dụ: foreach(var detail in newBookingDetails) { _bookingDetailService.AddBookingDetail(detail); }

                    MessageBox.Show("Rooms booked successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    SearchAvailableRooms(); // Tải lại danh sách phòng trống
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during booking: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}