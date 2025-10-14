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
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public void AddRoomType(RoomType roomType)
        {
            RoomTypeDAO.Add(roomType);
        }

        public void DeleteRoomType(RoomType roomType)
        {
            RoomTypeDAO.Delete(roomType);
        }

        public List<RoomType> GetAllRoomType()
        {
            return RoomTypeDAO.GetALl();
        }

        public void UpdateRoomType(RoomType roomType)
        {
            RoomTypeDAO.Update(roomType);
        }
    }
}
