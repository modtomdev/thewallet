using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;

namespace thewallet.Web.Externals.CoinMarketCap;

public class CMCDataAccess
{
    //fetches ETH, ADA, DOT, SUI, PI prices 60 times a day

    private readonly HttpClient _httpClient;
    private readonly string _connectionString = "";
    private readonly string _apiKey = "";
    private readonly List<string> _assetList = ["ETH", "ADA", "DOT", "SUI", "PI"];

    public CMCDataAccess(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _connectionString = configuration.GetConnectionString("db")
                                    ?? throw new Exception("Missing db connection string.");
        _apiKey = configuration.GetConnectionString("CMC_API_KEY")
                                    ?? throw new Exception("Missing cmc api key.");

    }

    public async Task<IEnumerable<Asset>?> GetPriceDataAsync()
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var assetList = new List<Asset>();

            foreach (var id in _assetList)
            {
                var response = await _httpClient.GetFromJsonAsync<CMCApi>(
                    $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest?symbol={id}&convert=EUR");

                if (response != null && response.Data != null && response.Data.ContainsKey(id))
                {
                    var cryptoData = response.Data[id];

                    assetList.Add(new Asset
                    {
                        Name = cryptoData.Name!,
                        CurrentValueEur = (decimal)cryptoData.Quote?.Eur?.Price!
                    });
                }
            }

            return assetList;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }


    public async Task SavePriceDataAsync(IEnumerable<Asset> assetList)
    {
        const string query = """

            UPDATE public.assets
            SET
            current_value_eur = @CurrentValueEur,
            value_timestamp = now()
            WHERE name = @Name;

            """;

        using var connection = new NpgsqlConnection(_connectionString);
        foreach (var asset in assetList)
        {
            await connection.ExecuteAsync(query, asset);
        }
    }
}