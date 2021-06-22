using HotelManagement.Enumerations;

namespace HotelManagement.Models
{
    public class RoomModel : BaseModel
    {
        public RoomTypeEnum RoomType { get; set; }

        public string Description { get; set; }

        public int NumberOfBeds { get; set; }
    }
}
