using HotelManagement.Models;
using HotelManagement.Services;
using HotelManagement.Views;
using NSubstitute;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Xunit;

namespace HotelManagement.Test.Services
{
    public class NavigationServiceTests
    {
        [Fact]
        public void NavigateTo_NavigationChanged()
        {
            var navigationService = new NavigationService();

            var navigationSubject = new Subject<(IView, BaseModel)>();

            navigationService.WhenNavigationChanged.Returns(navigationSubject.AsObservable());

            (IView, BaseModel) value = (Substitute.For<IRoomDetailView>(), null);

            navigationSubject.OnNext(value);

        }
    }
}
