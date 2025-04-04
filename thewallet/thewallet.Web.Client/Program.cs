using ApexCharts;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using thewallet.Shared.Interfaces;
using thewallet.Shared.Interfaces.CRUD;
using thewallet.Shared.Services;
using thewallet.Shared.Services.CRUD;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the thewallet.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddApexCharts(e =>
{
    e.GlobalOptions = new ApexChartBaseOptions
    {
        Debug = true,
        Theme = new Theme { Palette = PaletteType.Palette6 }
    };
});

builder.Services.AddScoped(sp => new HttpClient
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
builder.Services.AddScoped<IFrontService, FrontService>();

await builder.Build().RunAsync();
