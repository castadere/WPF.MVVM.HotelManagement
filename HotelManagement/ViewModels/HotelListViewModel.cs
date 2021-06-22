using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement.ViewModels
{
    public class HotelListViewModel : BaseItemListViewModel<HotelModel>
    {
        public HotelListViewModel(IHotelDataService hotelService) : base(hotelService)
        {
        }
    }
}
