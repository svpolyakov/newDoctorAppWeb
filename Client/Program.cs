using Blazored.Modal;
using DoctorAppWeb.Client.Services;
using DoctorAppWeb.Shared.SharedServices;
using MudBlazor.Services;
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
using Blazored.LocalStorage;

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
            builder.Services.AddMudServices();
            builder.Services.AddSingleton<StateContainer>();
            builder.Services.AddBlazoredLocalStorage();
            //builder.Services.AddApiAuthorization();
            await builder.Build().RunAsync();
        }
    }
}
