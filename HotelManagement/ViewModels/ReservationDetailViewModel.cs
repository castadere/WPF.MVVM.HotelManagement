using HotelManagement.Models;
using HotelManagement.Services;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace HotelManagement.ViewModels
{
    public class ReservationDetailViewModel : BaseViewModel
    {
        #region Private fields

        private readonly IRoomDataService _roomService;
        private ReservationModel _reservation;

        #endregion

        #region Constructors

        public ReservationDetailViewModel(
            IRoomDataService roomService,
            INavigationService navigationService)
        {
            _roomService = roomService;

            navigationService.WhenNavigationChanged
                                .Subscribe(v => { Test(v); });
        }

        private void Test(object x)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        public ReservationModel Reservation
        {
            get
            {
                return _reservation;
            }

            set
            {
                if (_reservation == value)
                {
                    return;
                }

                SetProperty(ref _reservation, value);
            }
        }

        public ObservableCollection<RoomModel> AvailableRooms { get; private set; }

        #endregion

    }
}
