using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Dialogs;
using System.Windows;

namespace HoLeQuocKhanhWPF.Views.Dialogs
{
    public partial class BookingDetailDialog : Window
    {
        public BookingDetailDialog(BookingReservation reservation)
        {
            InitializeComponent();
            DataContext = new BookingDetailDialogViewModel(reservation);
        }

  
    }
}