using DynamicData;
using DynamicData.Binding;
using HotelManagement.Models;
using HotelManagement.Services;
using HotelManagement.Views;
using System;
using System.Linq;

namespace HotelManagement.ViewModels
{
    public class RoomListViewModel : BaseItemListViewModel<RoomModel>
    {
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _editCommand;
        private readonly INavigationService _navigationService;

        public RoomListViewModel(
            IRoomDataService roomDataService,
            INavigationService navigationService) : base(roomDataService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand AddCommand => _addCommand
          ?? new DelegateCommand(NavigateToItemDetail);

        public DelegateCommand EditCommand => _editCommand
            ?? new DelegateCommand(NavigateToItemDetail);

        private void NavigateToItemDetail(object obj)
        {
            if (SelectedItem == null)
            {
                return;
            }

            _navigationService.NavigateTo<IRoomDetailView>(SelectedItem);
        }
    }
}
