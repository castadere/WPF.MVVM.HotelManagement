using Unity;

namespace HotelManagement.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.Container.Resolve<MainViewModel>();

        public RoomListViewModel RoomListViewModel => App.Container.Resolve<RoomListViewModel>();
        
        public RoomDetailViewModel RoomDetailViewModel => App.Container.Resolve<RoomDetailViewModel>();

        public ReservationListViewModel ReservationListViewModel => App.Container.Resolve<ReservationListViewModel>();
    }
}
