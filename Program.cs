using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TG.Blazor.IndexedDB;

namespace thanks
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddIndexedDB(dbStore => {
                dbStore.DbName = "ThanksDb";
                dbStore.Version = 1;
                dbStore.Stores.Add(new StoreSchema {
                    Name = "ThanksNotes",
                    PrimaryKey = new IndexSpec { Name = "Id", KeyPath = "id", Auto = true},
                });
            });
            await builder.Build().RunAsync();
        }
    }
}
