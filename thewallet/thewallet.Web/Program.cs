using thewallet.Shared.Services;
using thewallet.Web.Components;
using thewallet.Web.Endpoints;
using thewallet.Web.Externals;
using thewallet.Web.Externals.CoinMarketCap;
using thewallet.Web.Externals.YahooFinance;
using thewallet.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

// Add device-specific services used by the thewallet.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddScoped<IAccountTransactionService, AccountTransactionDataAccess>();
builder.Services.AddScoped<IAccountService, AccountDataAccess>();
builder.Services.AddScoped<ICategoryService, CategoryDataAccess>();
builder.Services.AddScoped<IAssetService, AssetDataAccess>();
builder.Services.AddScoped<IAssetHoldingService, AssetHoldingDataAccess>();
builder.Services.AddScoped<IGraphSnapshotService, GraphSnapshotDataAccess>();
builder.Services.AddScoped<ITransferService, TransferDataAccess>();
builder.Services.AddScoped<IUserService, UserDataAccess>();
builder.Services.AddScoped<IRecurringTransactionService, RecurringTransactionDataAccess>();

builder.Services.AddScoped<IOverviewService, OverviewDataAccess>();

builder.Services.AddHttpClient<CMCDataAccess>();
builder.Services.AddScoped<CMCDataAccess>();
builder.Services.AddScoped<YahooScraper>();

builder.Services.AddHostedService<PriceUpdater>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseWebAssemblyDebugging();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint("/openapi/v1.json", builder.Environment.ApplicationName);
    });
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(thewallet.Shared._Imports).Assembly,
        typeof(thewallet.Web.Client._Imports).Assembly);

app.MapOverviewEndpoints();
app.MapUserEndpoints();
app.MapAccountEndpoints();
app.MapCategoryEndpoints();
app.MapGraphSnapshotEndpoints();
app.MapTransferEndpoints();
app.MapRecurringTransactionEndpoints();
app.MapAssetEndpoints();
app.MapAssetHoldingEndpoints();

app.Run();
