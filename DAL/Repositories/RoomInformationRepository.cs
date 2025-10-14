using BussinessObjects.Models;
using DAL.DAO;
using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public void AddRoomInformation(RoomInformation roomInformation)
        {
            RoomInformationDAO.Add(roomInformation);
        }

        public void DeleteRoomInformation(RoomInformation roomInformation)
        {
            RoomInformationDAO.delete(roomInformation);
        }

        public List<RoomInformation> GetAllRoomInformation()
        {
            return RoomInformationDAO.GetAll();
        }

        public void UpdateRoomInformation(RoomInformation roomInformation)
        {
            RoomInformationDAO.Update(roomInformation);
        }
    }
}
