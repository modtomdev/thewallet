using Blazorise.Charts;
using thewallet.Shared.Models.DTOs.Overview;

namespace thewallet.Shared.Pages.Overview;

public partial class Index
{
    private string Factor => FormFactor.GetFormFactor();
    private string Platform => FormFactor.GetPlatform();

    private IEnumerable<AccountDTO> _accounts = [];
    private IEnumerable<GraphDTO> _graph = [];

    private decimal _totalValue;

    private LineChart<double> _chart = new();
    private List<string> _labels = [];
    private List<double> _data = [];


    protected override async Task OnInitializedAsync()
    {
        _accounts = await OverviewService.GetAccountDTOsAsync();
        _graph = await OverviewService.GetGraphDTOsAsync();
        _totalValue = Math.Round(_accounts.Sum(x => x.TotalValueEur), 2);
        foreach (var item in _graph)
        {
            _data.Add((double)item.TotalValueEur);
            _labels.Add(item.SnapshotTimestamp.ToString("yyyy/MM/dd"));
        }
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await HandleRedraw();
        }
    }

    async Task HandleRedraw()
    {
        await _chart.Clear();

        await _chart.AddLabelsDatasetsAndUpdate(_labels, GetLineChartDataset());
    }

    LineChartDataset<double> GetLineChartDataset()
    {
        return new LineChartDataset<double>
        {
            Label = "Net Worth",
            Data = _data,
            BackgroundColor = backgroundColors,
            BorderColor = borderColors,
            Fill = true,
            PointRadius = 3,
            CubicInterpolationMode = "monotone",
        };
    }

    List<string> backgroundColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 0.2f), ChartColor.FromRgba(54, 162, 235, 0.2f), ChartColor.FromRgba(255, 206, 86, 0.2f), ChartColor.FromRgba(75, 192, 192, 0.2f), ChartColor.FromRgba(153, 102, 255, 0.2f), ChartColor.FromRgba(255, 159, 64, 0.2f) };
    List<string> borderColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 1f), ChartColor.FromRgba(54, 162, 235, 1f), ChartColor.FromRgba(255, 206, 86, 1f), ChartColor.FromRgba(75, 192, 192, 1f), ChartColor.FromRgba(153, 102, 255, 1f), ChartColor.FromRgba(255, 159, 64, 1f) };
}