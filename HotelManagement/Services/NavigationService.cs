using HotelManagement.Models;
using HotelManagement.Views;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Unity;

namespace HotelManagement.Services
{
    public class NavigationService : INavigationService
    {
        #region Private fields

        // private readonly Subject<IView> _navigationChangedSubscription = new Subject<IView>();
        
        private readonly Subject<(IView, BaseModel)> _navigationChangedSubscription = new Subject<(IView, BaseModel)>();

        private readonly Dictionary<string, Type> _viewMapping = new Dictionary<string, Type>();

        #endregion

        #region Observables

        //public IObservable<IView> WhenNavigationChanged => _navigationChangedSubscription.AsObservable();

        public IObservable<(IView, BaseModel)> WhenNavigationChanged => _navigationChangedSubscription.AsObservable();

        #endregion

        #region Public methods

        public void NavigateTo<TView>() where TView : IView
        {
            var view = App.Container.Resolve<TView>();
            if (view == null)
            {
                throw new InvalidOperationException();
            }

            _navigationChangedSubscription.OnNext((view, null));
        }

        public void NavigateTo<TView>(BaseModel item) where TView : IView
        {
            var view = App.Container.Resolve<TView>();
            if (view == null)
            {
                throw new InvalidOperationException();
            }

            _navigationChangedSubscription.OnNext((view, item));
        }

        #endregion
    }
}
