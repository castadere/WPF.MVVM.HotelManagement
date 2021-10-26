using HotelManagement.Models;
using HotelManagement.Services;
using HotelManagement.Views;
using System;
using System.Windows.Input;

namespace HotelManagement.ViewModels
{
    public class RoomListViewModel : BaseItemListViewModel<RoomModel>
    {
        #region Private fields

        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _editCommand;
        private readonly INavigationService _navigationService;

        #endregion

        #region Constructors

        public RoomListViewModel(
            IRoomDataService roomDataService,
            INavigationService navigationService) : base(roomDataService)
        {
            _navigationService = navigationService;

            SearchCommand = new DelegateCommand(ExecuteSearchCommand);
        }

        private void ExecuteSearchCommand(object obj)
        {
            // Logic

        }

        #endregion

        #region Commands

        public DelegateCommand SearchCommand { get; }

        public DelegateCommand AddCommand => _addCommand
          ?? new DelegateCommand(ExecuteAddCommand);

        public DelegateCommand EditCommand => _editCommand
            ?? new DelegateCommand(ExecuteEditCommand);

        #endregion

        #region Private methods

        private void ExecuteAddCommand(object obj)
        {
            _navigationService.NavigateTo<IRoomDetailView>(new RoomModel());
        }

        private void ExecuteEditCommand(object obj)
        {
            if (SelectedItem == null)
            {
                return;
            }

            _navigationService.NavigateTo<IRoomDetailView>(SelectedItem);
        }

        #endregion
    }
}
