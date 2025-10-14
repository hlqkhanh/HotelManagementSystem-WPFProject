using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Models
{
    public class BookingReservation
    {
        public int BookingReservationID { get; set; }
        public DateTime? BookingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public int CustomerID { get; set; }
        public byte BookingStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set;}

    }
}
