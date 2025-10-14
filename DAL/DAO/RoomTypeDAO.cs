using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class RoomTypeDAO
    {
        private static readonly List<RoomType> roomTypes = new List<RoomType>
        {
            new RoomType { RoomTypeID = 1, RoomTypeName = "Standard room", TypeDescription = "This is typically the most affordable option and provides basic amenities such as a bed, dresser, and TV.", TypenNote = "N/A" },
            new RoomType { RoomTypeID = 2, RoomTypeName = "Suite", TypeDescription = "Suites usually offer more space and amenities than standard rooms, such as a separate living area, kitchenette, and multiple bathrooms.", TypenNote = "N/A" },
            new RoomType { RoomTypeID = 3, RoomTypeName = "Deluxe room", TypeDescription = "Deluxe rooms offer additional features such as a balcony or sea view, upgraded bedding, and improved décor.", TypenNote = "N/A" },
            new RoomType { RoomTypeID = 4, RoomTypeName = "Executive room", TypeDescription = "Executive rooms are designed for business travelers and offer perks such as free breakfast, evening drink, and high-speed internet.", TypenNote = "N/A" },
            new RoomType { RoomTypeID = 5, RoomTypeName = "Family Room", TypeDescription = "A room specifically designed to accommodate families, often with multiple beds and additional space for children.", TypenNote = "N/A" },
            new RoomType { RoomTypeID = 6, RoomTypeName = "Connecting Room", TypeDescription = "Two or more rooms with a connecting door, providing flexibility for larger groups or families traveling together.", TypenNote = "N/A" },
            new RoomType { RoomTypeID = 7, RoomTypeName = "Penthouse Suite", TypeDescription = "An extravagant, top-floor suite with exceptional views and exclusive amenities, typically chosen for special occasions or VIP guests.", TypenNote = "N/A" },
            new RoomType { RoomTypeID = 8, RoomTypeName = "Bungalow", TypeDescription = "A standalone cottage-style accommodation, providing privacy and a sense of seclusion often within a resort setting", TypenNote = "N/A" }
        };

        public static List<RoomType> GetALl()
        {
            return roomTypes;
        }

        public static void Add(RoomType roomType)
        {
            roomTypes.Add(roomType);
        }

        public static void Update(RoomType roomType)
        {
            foreach (RoomType rt in roomTypes.ToList())
            {
                if(rt.RoomTypeID == roomType.RoomTypeID)
                {
                    rt.TypeDescription = roomType.TypeDescription;
                    rt.TypenNote = roomType.TypenNote;
                    rt.RoomInformations = roomType.RoomInformations;
                    rt.RoomTypeName = roomType.RoomTypeName;
                }
            }
        }

        public static void Delete(RoomType roomType)
        {
            roomTypes.Remove(roomType);
        }
    }
}
