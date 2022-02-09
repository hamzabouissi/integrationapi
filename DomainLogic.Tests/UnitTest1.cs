using System.Collections.Generic;
using DomainLogic.services.ratehawk;
using Xunit;

namespace DomainLogic.Tests;

public class RateHawkClientTest
{
    [Fact]
    public void retrun_hotels_list_when_api_account_is_not_expired()
    {
        // Arrange
        // var serviceProvider = new ServiceCollection()
        //     .AddLogging()
        //     .BuildServiceProvider();
        // var factory = serviceProvider.GetService<ILoggerFactory>();
        // var logger = factory.CreateLogger<RatehawkClient>();
        // var client = new RatehawkClient(logger);
        // var request = new SearchHotelByRegionRequest
        // {
        //     regionId = 178043,
        //     checkin = "2022-02-01",
        //     checkout = "2022-02-05",
        //     language = LanguagesEnum.ar,
        //     guests = new List<Guest>()
        //     {
        //         new Guest(4,new List<int>())
        //     }
        // };
        // // Act
        // var result =  client.list_hotels_by_region(request).GetAwaiter().GetResult();
        //
        // //Assert
        // Assert.True(result.IsSuccess);

    }
    
}