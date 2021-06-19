using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Client {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<Services.UserBackendAccessService>();
            builder.Services.AddScoped<Services.TestsDefinitionBackendAccessService>();

            builder.Services.AddScoped<Services.LectureBackendAccessService>();

            builder.Services.AddSingleton<Services.UserServicee>();
            builder.Services.AddSingleton<Services.AppState>();

            builder.Services.AddScoped<Services.NewsBackendAccessService>();
            builder.Services.AddScoped<Services.CompletedTestBackendAccessService>();
            
            await builder.Build().RunAsync();
        }
    }
}
