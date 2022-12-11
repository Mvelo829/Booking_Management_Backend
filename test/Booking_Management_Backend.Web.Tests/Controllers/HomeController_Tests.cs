using System.Threading.Tasks;
using Booking_Management_Backend.Models.TokenAuth;
using Booking_Management_Backend.Web.Controllers;
using Shouldly;
using Xunit;

namespace Booking_Management_Backend.Web.Tests.Controllers
{
    public class HomeController_Tests: Booking_Management_BackendWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}