using System.Collections.Generic;

namespace HotelManagement.Models
{
    public class HotelModel : BaseModel
    {
        public string Name { get; set; }

        public ICollection<RoomModel> Rooms { get; } = new HashSet<RoomModel>();
    }
}
