using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IRoomTypeRepository
    {
        List<RoomType> GetAllRoomType();
        void AddRoomType(RoomType roomType);
        void DeleteRoomType(RoomType roomType);
        void UpdateRoomType(RoomType roomType);
    }
}
