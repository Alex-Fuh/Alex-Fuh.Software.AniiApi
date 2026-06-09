using Alex_Fuh.Software.AniiApi.Client;
using Alex_Fuh.Software.AniiApi.FrontEnd;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IAniiApiClient, AniiApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5142/");
});

await builder.Build().RunAsync();