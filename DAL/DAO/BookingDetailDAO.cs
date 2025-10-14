using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class BookingDetailDAO
    {
        private static readonly List<BookingDetail> bookingDetails = new List<BookingDetail>
        {
            new BookingDetail { BookingReservationID = 1, RoomID = 3, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 2), ActualPrice = 199.00m },
            new BookingDetail { BookingReservationID = 1, RoomID = 7, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 2), ActualPrice = 179.00m },
            new BookingDetail { BookingReservationID = 2, RoomID = 3, StartDate = new DateTime(2024, 1, 5), EndDate = new DateTime(2024, 1, 6), ActualPrice = 199.00m },
            new BookingDetail { BookingReservationID = 2, RoomID = 5, StartDate = new DateTime(2024, 1, 5), EndDate = new DateTime(2024, 1, 9), ActualPrice = 219.00m }
        };

        public static List<BookingDetail> GetAll()
        {
            return bookingDetails;
        }
    }
}
