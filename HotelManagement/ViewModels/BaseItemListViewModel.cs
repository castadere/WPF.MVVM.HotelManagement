using DynamicData;
using DynamicData.Binding;
using HotelManagement.Models;
using HotelManagement.Services;
using System;
using System.Linq;

namespace HotelManagement.ViewModels
{
    public abstract class BaseItemListViewModel<TBaseModel> : BaseViewModel where TBaseModel : BaseModel
    {
        #region Private fields

        private readonly DelegateCommand _removeCommand;
        private readonly IDataService<TBaseModel> _dataService;
        private readonly INavigationService _navigationService;

        private TBaseModel _selectedItem;

        #endregion

        #region Constructors

        public BaseItemListViewModel(
            IDataService<TBaseModel> dataService)
        {
            _dataService = dataService;
            
            InitializeSubscriptions(dataService);
        }

        #endregion

        #region Public properties

        public IObservableCollection<TBaseModel> Items { get; } = new ObservableCollectionExtended<TBaseModel>();

        public TBaseModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                if (_selectedItem == value)
                {
                    return;
                }

                SetProperty(ref _selectedItem, value);
            }
        }

        #endregion

        #region Commands

        public DelegateCommand RemoveCommand => _removeCommand
            ?? new DelegateCommand(RemoveItem);

        #endregion

        #region Private methods

        private void InitializeSubscriptions(IDataService<TBaseModel> dataService)
        {
            dataService.WhenModelsChanged
                .Connect()
                .Bind(Items)
                .Subscribe();
        }

        private void RemoveItem(object obj)
        {
            if (SelectedItem == null)
            {
                return;
            }

            _dataService.Remove(SelectedItem.Id);
        }

        #endregion
    }
}
