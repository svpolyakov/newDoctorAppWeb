using Blazored.Modal;
using DoctorAppWeb.Client.Services;
using DoctorAppWeb.Shared.SharedServices;
using MatBlazor;
using IndexedDB.Blazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace DoctorAppWeb.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<CustomStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IPatientsService, PatientsService>();
            builder.Services.AddScoped<IDataWCFService, HttpDataWCFService>();
            builder.Services.AddSingleton<IIndexedDbFactory, IndexedDbFactory>();
            builder.Services.AddBlazoredModal();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDc0MTA5QDMxMzkyZTMyMmUzMFVra1BsR1FQcjE5NU8yVFJheVNtZE1FandrblZWNTFvTE0xU3VodEVwRU09;NDc0MTEwQDMxMzkyZTMyMmUzMEFQak9zQ3h1RTRuWDRUa3pXaThEYnNxQXlFd1dOT2F2K2FpVllxN0dPbkU9");
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddMatBlazor();
            //builder.Services.AddApiAuthorization();
            await builder.Build().RunAsync();
        }
    }
}
