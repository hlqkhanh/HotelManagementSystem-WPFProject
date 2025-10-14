using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IRoomTypeService
    {
        List<RoomType> GetRoomTypeList();
        void AddRoomType(RoomType roomType);
        void DeleteRoomType(RoomType roomType);
        void UpdateRoomType(RoomType roomType);
    }
}
