using HotelManagement.Models;
using HotelManagement.Views;
using System;

namespace HotelManagement.Services
{
    public interface INavigationService
    {
        IObservable<(IView, BaseModel)> WhenNavigationChanged { get; }

        void NavigateTo<TView>() where TView : IView;

        void NavigateTo<TView>(BaseModel item) where TView : IView;
    }
}
