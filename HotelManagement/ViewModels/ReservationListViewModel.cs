using DynamicData;
using DynamicData.Binding;
using HotelManagement.Models;
using HotelManagement.Services;
using HotelManagement.Views;
using System;

namespace HotelManagement.ViewModels
{
    public class ReservationListViewModel : BaseItemListViewModel<ReservationModel>
    {
        #region Private fields

        private readonly DelegateCommand _navigateToReservationDetail;
        private readonly IReservationDataService _reservationService;
        private readonly INavigationService _navigationService;

        private ReservationModel _selectedReservation = new ReservationModel();

        #endregion

        #region Constructors

        public ReservationListViewModel(
            IReservationDataService reservationService,
            INavigationService navigationService) : base(reservationService)
        {
            _reservationService = reservationService;
            _navigationService = navigationService;
            
            _reservationService.WhenModelsChanged
                .Connect()
                .Bind(Items)
                .Subscribe();
        }

        #endregion

        #region Properties

        //public IObservableCollection<ReservationModel> Reservations { get; } = new ObservableCollectionExtended<ReservationModel>();

        //public ReservationModel SelectedReservation
        //{
        //    get
        //    {
        //        return _selectedReservation;
        //    }

        //    set
        //    {
        //        if (_selectedReservation == value)
        //        {
        //            return;
        //        }

        //        SetProperty(ref _selectedReservation, value);
        //    }
        //}

        #endregion

        #region Commands

        //public DelegateCommand NavigateToReservationDetail => _navigateToReservationDetail ??
        //    new DelegateCommand(ExecuteNavigateToReservationDetail, CanExecuteNavigateToReservationDetail);

        //private bool CanExecuteNavigateToReservationDetail(object obj)
        //{
        //    return SelectedReservation != null;
        //}

        //private void ExecuteNavigateToReservationDetail(object obj)
        //{
        //    _navigationService.NavigateTo<IReservationDetailView>();
        //}

        #endregion
    }
}
