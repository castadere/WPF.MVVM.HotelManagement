using HotelManagement.Enumerations;

namespace HotelManagement.Models
{
    public class RoomModel : BaseModel
    {
        public string Description { get; set; }

        public RoomTypeEnum RoomType { get; set; }

        public int NumberOfBeds { get; set; }

        public virtual HotelModel Hotel { get; set; }
    }
}
