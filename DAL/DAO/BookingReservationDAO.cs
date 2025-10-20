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
            var allCustomer = CustomerDAO.GetAll();

            foreach (var booking in bookingReservations)
            {
                if (booking.Customer == null)
                {
                    booking.Customer = allCustomer.FirstOrDefault(cus => cus.CustomerID == cus.CustomerID);
                }

                var bookingDetailList = BookingDetailDAO.GetBookingDetailsByReservationID(booking.BookingReservationID);
                booking.BookingDetails = bookingDetailList;
            }

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
            reservation.BookingReservationID = GetMaxBookingReservationID() + 1;
            bookingReservations.Add(reservation);
        }

        public static int GetMaxBookingReservationID()
        {
            if (bookingReservations.Count == 0)
                return 0; 

            return bookingReservations.Max(b => b.BookingReservationID);
        }
    }
}
