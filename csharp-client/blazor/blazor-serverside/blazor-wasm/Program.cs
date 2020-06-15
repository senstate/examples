using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Senstate.NetStandard;
using Senstate.CSharp_Client;

namespace blazor_wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webSocket = new NetStandardWebSocketImplementation();
            webSocket.ExceptionThrown += (sender, e) =>  // Optional if you want to catch Connection issues
            {
                throw e.Exception;
            };

            SenstateContext.SerializerInstance = new NetStandardJsonNetImplementation();
            SenstateContext.WebSocketInstance = webSocket;
            SenstateContext.RegisterApp("C# Blazor WASM");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();

            await builder.Build().RunAsync();
        }
    }
}
