using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using thewallet.Shared.Services;
using thewallet.Web.Client.Services.DomainServices;
using thewallet.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the thewallet.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddSingleton(new HttpClient()
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddScoped<IAccountTransactionService, AccountTransactionService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IAssetHoldingService, AssetHoldingService>();
builder.Services.AddScoped<IGraphSnapshotService, GraphSnapshotService>();
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRecurringTransactionService, RecurringTransactionService>();

builder.Services.AddScoped<IOverviewService, OverviewService>();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

await builder.Build().RunAsync();
