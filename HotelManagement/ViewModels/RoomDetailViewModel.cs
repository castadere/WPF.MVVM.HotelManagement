using HotelManagement.Models;
using HotelManagement.Services;
using System;
using System.Reactive.Linq;

namespace HotelManagement.ViewModels
{
    public class RoomDetailViewModel : BaseViewModel
    {
        public RoomDetailViewModel(INavigationService navigationService)
        {
            navigationService.WhenNavigationChanged
                .Select(x => x.Item2)
                .Where(room => { return IsRoomModel(room); })
                .Subscribe(room => SetSelectedItem(room));
        }

        private RoomModel _room;

        public RoomModel Room
        {
            get
            {
                return _room;
            }

            set
            {
                if (_room == value)
                {
                    return;
                }

                SetProperty(ref _room, value);
            }
        }

        private void SetSelectedItem(BaseModel selectedRoom)
        {
            Room = (RoomModel)selectedRoom;
        }

        private bool IsRoomModel(BaseModel room)
        {
            if (room == null)
            {
                return false;
            }

            return room.GetType() == typeof(RoomModel);
        }
    }
}
