using HotelManagement.Services;
using HotelManagement.ViewModels;
using HotelManagement.Views;
using System.Windows;
using Unity;

namespace HotelManagement
{
    public partial class App : Application
    {
        public static UnityContainer Container = new UnityContainer();

        public App()
        {
            RegisterViews();
            RegisterViewModels();
            RegisterServices();
        }

        private static void RegisterServices()
        {
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IRoomDataService, RoomDataService>();
            Container.RegisterSingleton<IReservationDataService, ReservationDataService>();
            Container.RegisterSingleton<IHotelDataService, HotelDataService>();
        }

        private static void RegisterViews()
        {
            Container.RegisterSingleton<IRoomListView, RoomListView>();
            Container.RegisterSingleton<IRoomDetailView, RoomDetailView>();
            Container.RegisterSingleton<IReservationListView, ReservationListView>();
            Container.RegisterSingleton<IReservationDetailView, ReservationDetailView>();
            Container.RegisterSingleton<IHotelListVew, HotelListView>();
        }

        private static void RegisterViewModels()
        {
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<RoomListViewModel>();
            Container.RegisterSingleton<RoomDetailViewModel>();
            Container.RegisterSingleton<ReservationDetailViewModel>();
        }
    }
}
