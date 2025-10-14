using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Models
{
    public class RoomInformation : ICloneable
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string? RoomDescription { get; set; }
        public int RoomMaxCapacity { get; set; }
        public int RoomStatus { get; set; }
        public decimal RoomPricePerDate { get; set; }
        public int RoomTypeID { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual RoomType RoomType { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
