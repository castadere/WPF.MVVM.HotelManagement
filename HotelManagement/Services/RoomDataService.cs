using HotelManagement.Models;
using System.Collections.Generic;

namespace HotelManagement.Services
{
    public class RoomDataService : BaseDataService<RoomModel>, IRoomDataService
    {
        public RoomDataService()
        {
            var items = new List<RoomModel>
            {
                new RoomModel
                {
                    Id = 1,
                    Description = "Room 1"
                },
                new RoomModel
                {
                    Id = 2,
                    Description = "Room 2"
                }
            };


            AddOrUpdate(items);
        }
    }
}
