using Newtonsoft.Json;
using SpaceXLaunchAPI.Models;

namespace SpaceXLaunchAPI.Endpoints
{
    public static class EndpointsAccessor
    {
        public static async Task<IResult> GetLaunch(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return Results.BadRequest("Invalid launch ID");
            }

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.spacexdata.com/v4/");
            HttpResponseMessage? launchResponse = null;
            try
            {
                launchResponse = await httpClient.GetAsync($"launches/{id}");
                launchResponse.EnsureSuccessStatusCode();

                var launchJson = await launchResponse.Content.ReadAsStringAsync();
                var launch = JsonConvert.DeserializeObject<Launch>(launchJson);

                if (launch is { Rocket: not null })
                {
                    var rocketResponse = await httpClient.GetAsync($"rockets/{launch.Rocket}");
                    rocketResponse.EnsureSuccessStatusCode();

                    var rocketJson = await rocketResponse.Content.ReadAsStringAsync();
                    var rocket = JsonConvert.DeserializeObject<Rocket>(rocketJson);
                    launch.RocketName = rocket!.Name;
                    launch.RocketCountry = rocket!.Country;
                    launch.RocketCompany = rocket!.Company;
                }

                if (launch is { LaunchPad: not null })
                {
                    var launchPadResponse = await httpClient.GetAsync($"launchpads/{launch.LaunchPad}");
                    launchPadResponse.EnsureSuccessStatusCode();

                    var launchPadJson = await launchPadResponse.Content.ReadAsStringAsync();
                    var launchPad = JsonConvert.DeserializeObject<LaunchPad>(launchPadJson);
                    launch.LaunchPadName = launchPad!.Name;
                    launch.LaunchPadFullName = launchPad!.Full_Name;
                    launch.LaunchPadRegion = launchPad!.Region;
                }

                return Results.Ok(launch);
            }
            catch (HttpRequestException)
            {
                return Results.StatusCode(statusCode: (int)launchResponse!.StatusCode);
            }
        }
    }
}
