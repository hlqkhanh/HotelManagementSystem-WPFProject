using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class RoomInformationDAO
    {
        private static readonly List<RoomInformation> roomInformations = new List<RoomInformation>
        {
            new RoomInformation { RoomID = 1, RoomNumber = "2364", RoomDescription = "A basic room with essential amenities, suitable for individual travelers or couples.", RoomMaxCapacity = 3, RoomTypeID = 1, RoomStatus = 1, RoomPricePerDate = 149.00m },
            new RoomInformation { RoomID = 2, RoomNumber = "3345", RoomDescription = "Deluxe rooms offer additional features such as a balcony or sea view, upgraded bedding, and improved décor.", RoomMaxCapacity = 5, RoomTypeID = 3, RoomStatus = 1, RoomPricePerDate = 299.00m },
            new RoomInformation { RoomID = 3, RoomNumber = "4432", RoomDescription = "A luxurious and spacious room with separate living and sleeping areas, ideal for guests seeking extra comfort and space.", RoomMaxCapacity = 4, RoomTypeID = 2, RoomStatus = 1, RoomPricePerDate = 199.00m },
            new RoomInformation { RoomID = 5, RoomNumber = "3342", RoomDescription = "Foor 3, Window in the North West ", RoomMaxCapacity = 5, RoomTypeID = 5, RoomStatus = 1, RoomPricePerDate = 219.00m },
            new RoomInformation { RoomID = 7, RoomNumber = "4434", RoomDescription = "Floor 4, main window in the South ", RoomMaxCapacity = 4, RoomTypeID = 1, RoomStatus = 1, RoomPricePerDate = 179.00m }
        };


        static RoomInformationDAO()
        {
            var allRoomTypes = RoomTypeDAO.GetALl();

            foreach (var room in roomInformations)
            {
                if (room.RoomType == null)
                {
                    room.RoomType = allRoomTypes.FirstOrDefault(rt => rt.RoomTypeID == room.RoomTypeID);
                }
            }
        }

        public static List<RoomInformation> GetAll()
        {
            
            return roomInformations;
        }

        public static void Add(RoomInformation room)
        {
            roomInformations.Add(room);
        }

        public static void Update(RoomInformation room)
        {
            var roomToUpdate = roomInformations.FirstOrDefault(r => r.RoomID == room.RoomID);
            if (roomToUpdate != null)
            {
                roomToUpdate.RoomNumber = room.RoomNumber;
                roomToUpdate.RoomDescription = room.RoomDescription;
                roomToUpdate.RoomMaxCapacity = room.RoomMaxCapacity;
                roomToUpdate.RoomStatus = room.RoomStatus;
                roomToUpdate.RoomPricePerDate = room.RoomPricePerDate;

                if (roomToUpdate.RoomTypeID != room.RoomTypeID)
                {
                    roomToUpdate.RoomTypeID = room.RoomTypeID;
                    roomToUpdate.RoomType = RoomTypeDAO.GetALl().FirstOrDefault(rt => rt.RoomTypeID == room.RoomTypeID);
                }
            }
        }

        public static void Delete(RoomInformation room)
        {
            var roomToRemove = roomInformations.FirstOrDefault(r => r.RoomID == room.RoomID);
            if (roomToRemove != null)
            {
                roomInformations.Remove(roomToRemove);
            }
        }

        public static RoomInformation GetRoomInformation(int roomID)
        {
            var room = roomInformations.FirstOrDefault(r => r.RoomID == roomID);

            if (room != null && room.RoomType == null) 
            {
                room.RoomType = RoomTypeDAO.GetALl().FirstOrDefault(rt => rt.RoomTypeID == room.RoomTypeID);
            }

            return room;
        }
    }
}