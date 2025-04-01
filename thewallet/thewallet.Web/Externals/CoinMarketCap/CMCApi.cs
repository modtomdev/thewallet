using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace thewallet.Web.Externals.CoinMarketCap;

public class CMCApi
{
    [JsonProperty("status")]
    public Status? Status { get; set; }

    [JsonProperty("data")]
    public Dictionary<string, CryptoData>? Data { get; set; }
}
public class Status
{
    [JsonProperty("timestamp")]
    public DateTime? Timestamp { get; set; }
}

public class CryptoData
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("symbol")]
    public string? Symbol { get; set; }

    [JsonProperty("quote")]
    public Quote? Quote { get; set; }
}

public class Quote
{
    [JsonProperty("EUR")]
    public EUR? Eur { get; set; }
}

public class EUR
{
    [JsonProperty("price")]
    public double? Price { get; set; }
}
