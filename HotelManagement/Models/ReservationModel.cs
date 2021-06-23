using System;

namespace HotelManagement.Models
{
    public class ReservationModel : BaseModel
    {
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public string Comments { get; set; }

        public int NumberOfAdults { get; set; }

        public int NumberOfChildren { get; set; }

        public virtual RoomModel Room { get; set; }
    }
}
