using Microsoft.AspNetCore.Http.HttpResults;
using SpaceXLaunchAPI.Endpoints;
using SpaceXLaunchAPI.Models;
using ExpectedObjects;
using System.Net;

namespace SpaceXLaunchAPI.Tests
{
    public class LaunchEndpointTests
    {
        [Fact]
        public async void GetLaunch_ValidId_ReturnsLaunch()
        {
            // Arrange
            var id = "633f71240531f07b4fdf59bb";
            var expectedResult = new Launch
            {
                Id = "633f71240531f07b4fdf59bb",
                Name = "Galaxy 33 (15R) & 34 (12R)",
                Details = null,
                Success = null,
                Upcoming = true,
                Date_Utc = DateTime.Parse("10/8/2022 11:05:00 PM"),
                Static_Fire_Date_Utc = null,
                Flight_Number = 188,
                Tbd = false,
                Net = false,
                Window = null,
                Rocket = "5e9d0d95eda69973a809d1ec",
                RocketName = "Falcon 9",
                RocketCountry = "United States",
                RocketCompany = "SpaceX",
                LaunchPad = "5e9e4501f509094ba4566f84",
                LaunchPadName = "CCSFS SLC 40",
                LaunchPadFullName = "Cape Canaveral Space Force Station Space Launch Complex 40",
                LaunchPadRegion = "Florida"
            }.ToExpectedObject();

            // Act
            var result = await EndpointsAccessor.GetLaunch(id) as Ok<Launch>;

            // Assert
            expectedResult.ShouldEqual(result!.Value);
        }

        [Fact]
        public async void GetLaunch_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var id = "123";
            var expectedStatusCode = (int)HttpStatusCode.NotFound;

            // Act
            var result = await EndpointsAccessor.GetLaunch(id) as StatusCodeHttpResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedStatusCode, result!.StatusCode);
        }

        [Fact]
        public async void GetLaunch_EmptyId_ReturnsNotFound()
        {
            // Arrange
            var id = string.Empty;
            string expectedResult = "Invalid launch ID";

            // Act
            var result = await EndpointsAccessor.GetLaunch(id) as BadRequest<string>;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result!.Value);
        }
    }
}
