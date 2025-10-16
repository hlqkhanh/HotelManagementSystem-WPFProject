using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class BookingReservationDAO
    {
        private static readonly List<BookingReservation> bookingReservations = new List<BookingReservation>
        {
            new BookingReservation { BookingReservationID = 1, BookingDate = new DateTime(2023, 12, 20), TotalPrice = 378.00m, CustomerID = 3, BookingStatus = 1 },
            new BookingReservation { BookingReservationID = 2, BookingDate = new DateTime(2023, 12, 21), TotalPrice = 1493.00m, CustomerID = 3, BookingStatus = 1 }
        };

        public static List<BookingReservation> GetAll()
        {
            return bookingReservations;
        }

        public static List<BookingReservation> GetBookingReservationsByCustomerID(int customerID)
        {
            List<BookingReservation> list = new List<BookingReservation>();
            foreach (BookingReservation br in bookingReservations.ToList())
            {
                if (br.CustomerID == customerID)
                {
                    list.Add(br);
                }
            }
            return list;
        }

        public static BookingReservation GetBookingReservation(int bookingReservationID)
        {
            foreach(BookingReservation br in bookingReservations.ToList())
            {
                if(br.BookingReservationID == bookingReservationID) { return br; }
            }

            return null;
        }

        public static void Add(BookingReservation reservation)
        {
            bookingReservations.Add(reservation);
        }
    }
}
