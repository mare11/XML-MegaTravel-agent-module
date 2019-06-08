using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestServiceReference;

namespace AgentApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            AccommodationPortClient accommodationPortClient = new AccommodationPortClient();
            getAccommodationRequest accommodationRequest = new getAccommodationRequest();
            accommodationRequest.name = "DA LI RADI? BRANKO";

            System.Diagnostics.Debug.WriteLine("BLA BLA BLA");

            System.Diagnostics.Debug.WriteLine(accommodationPortClient.getAccommodationAsync(accommodationRequest).Result.getAccommodationResponse.accommodation);

            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
