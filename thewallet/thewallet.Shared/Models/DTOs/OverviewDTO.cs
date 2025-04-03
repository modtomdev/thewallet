namespace thewallet.Shared.Models.DTOs;

public class OverviewDTO
{
    public int AccountId { get; set; }
    public string AccountName { get; set; } = default!;
    public decimal TotalValueEur { get; set; }
}
