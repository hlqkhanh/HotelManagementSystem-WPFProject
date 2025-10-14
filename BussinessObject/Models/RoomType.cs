using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Models
{
    public class RoomType
    {
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public string? TypeDescription { get; set; }
        public string? TypenNote { get; set; }

        public virtual ICollection<RoomInformation> RoomInformations { get; set; }
    }
}
