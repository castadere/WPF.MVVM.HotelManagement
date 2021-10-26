using HotelManagement.Enumerations;
using HotelManagement.Models;
using HotelManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace HotelManagement.ViewModels
{
    public class RoomDetailViewModel : BaseViewModel
    {
        #region Private fields

        private readonly IRoomDataService _roomDataService;
        private readonly DelegateCommand _clearCommand;
        private readonly DelegateCommand _submitCommand;

        private RoomModel _room;

        #endregion

        #region Constructors

        public RoomDetailViewModel(
            INavigationService navigationService,
            IRoomDataService roomDataService)
        {
            _roomDataService = roomDataService;

            navigationService.WhenNavigationChanged
                .Select(x => x.Item2)
                .Where(room => { return IsRoomModel(room); })
                .Subscribe(room => SetSelectedItem(room));
        }

        #endregion

        #region Properties

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

        public IEnumerable<RoomTypeEnum> RoomTypes { get; } = Enum.GetValues(typeof(RoomTypeEnum)).Cast<RoomTypeEnum>().ToList();

        #endregion

        #region Commands

        public DelegateCommand SubmitCommand => _submitCommand
            ?? new DelegateCommand(ExecuteSubmitCommand, CanExecuteSubmitCommand);

        public DelegateCommand ClearCommand => _clearCommand 
            ?? new DelegateCommand(ExecuteClearCommand);

        #endregion

        #region Private methods

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

        private bool CanExecuteSubmitCommand(object obj)
        {
            // todo: run validations
            return true;
        }

        private void ExecuteClearCommand(object obj)
        {
            Room = new RoomModel();
        }

        private void ExecuteSubmitCommand(object obj)
        {
            _roomDataService.AddOrUpdate(Room);
        }

        #endregion
    }
}
