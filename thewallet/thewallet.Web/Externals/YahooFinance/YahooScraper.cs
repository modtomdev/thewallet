using Npgsql;
using Dapper;
using thewallet.Shared.Models.DomainModels;
using YahooFinanceApi;

namespace thewallet.Web.Externals.YahooFinance;

public class YahooScraper
{
    private readonly IEnumerable<string> _assetStrings = ["XEON.MI","EURJPY=X"];
    private readonly string _connectionString = "";

    public YahooScraper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db") 
                                ?? throw new Exception("Missing db connection string.");
    }

    public async Task<IEnumerable<Asset>?> GetPriceDataAsync()
    {
        try
        {
            var assetList = new List<Asset>();
            foreach (var id in _assetStrings)
            {
                var securities = await Yahoo.Symbols(id).Fields(Field.RegularMarketPrice).QueryAsync();
                if (securities != null)
                {
                    assetList.Add(new Asset
                    {
                        Symbol = id,
                        CurrentValueEur = (decimal)securities[id].RegularMarketPrice
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
            WHERE symbol = @Symbol;

        """;

        using var connection = new NpgsqlConnection(_connectionString);
        foreach (var asset in assetList)
        {
            await connection.ExecuteAsync(query, asset);
        }
    }
}