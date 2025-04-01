using thewallet.Web.Externals.CoinMarketCap;
using thewallet.Web.Externals.YahooFinance;

namespace thewallet.Web.Externals;

public class PriceUpdater : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PriceUpdater> _logger;

    public PriceUpdater(IServiceProvider serviceProvider, ILogger<PriceUpdater> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {/*
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var cmcDataAccess = scope.ServiceProvider.GetRequiredService<CMCDataAccess>();
                var yahooScraper = scope.ServiceProvider.GetRequiredService<YahooScraper>();

                try
                {
                    var cmcAssets = await cmcDataAccess.GetPriceDataAsync();
                    
                    if (cmcAssets is not null)
                    {
                        if (cmcAssets.Any())
                        {
                            await cmcDataAccess.SavePriceDataAsync(cmcAssets);
                            _logger.LogInformation("CMC prices updated!");
                        }
                        else
                        {
                            _logger.LogWarning("No data returned from CMC!");
                        }
                    }

                    var yahooAssets = await yahooScraper.GetPriceDataAsync();
                    if (yahooAssets is not null)
                    {
                        if (yahooAssets.Any())
                        {
                            await yahooScraper.SavePriceDataAsync(yahooAssets);
                            _logger.LogInformation("Yahoo prices updated!");
                        }
                        else
                        {
                            _logger.LogWarning("No data returned from Yahoo!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error during external update: {ex.Message}");
                }
            }

            await Task.Delay(TimeSpan.FromMinutes(6), stoppingToken);
        }*/
    }
}
