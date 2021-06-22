using HotelManagement.Services;
using HotelManagement.Views;
using System;

namespace HotelManagement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Private fields

        private readonly INavigationService _navigationService;
        private readonly DelegateCommand _navigateToRooms;
        private readonly DelegateCommand _navigateToReservations;

        private object _selectedContent;

        #endregion

        #region Constructors

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            navigationService.WhenNavigationChanged
              .Subscribe(v => { SelectedContent = v.Item1; });

            navigationService.NavigateTo<IReservationListView>();
        }

        #endregion

        #region Properties

        public object SelectedContent
        {
            get
            {
                return _selectedContent;
            }

            set
            {
                if (_selectedContent == value)
                {
                    return;
                }

                SetProperty(ref _selectedContent, value);
            }
        }

        #endregion

        #region Commands

        public DelegateCommand NavigateToRooms => _navigateToRooms ?? 
            new DelegateCommand(ExecuteNavigateToRooms);
        
        private void ExecuteNavigateToRooms(object obj)
        {
            _navigationService.NavigateTo<IRoomListView>();
        }

        public DelegateCommand NavigateToReservations => _navigateToReservations ??
            new DelegateCommand(ExecuteNavigateToReservations);

        private void ExecuteNavigateToReservations(object obj)
        {
            _navigationService.NavigateTo<IReservationListView>();
        }

        #endregion
    }
}
