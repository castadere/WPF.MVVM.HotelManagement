using HotelManagement.Services;
using HotelManagement.Views;
using Xunit;

namespace HotelManagement.Test.Services
{
    public class NavigationServiceTests
    {
        [Fact]
        public void NavigateTo_NavigationChanged()
        {
            var navigationService = new NavigationService();

            navigationService.NavigateTo<IRoomDetailView>();
        }
    }
}
