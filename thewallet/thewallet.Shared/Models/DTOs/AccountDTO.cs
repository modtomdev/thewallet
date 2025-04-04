namespace thewallet.Shared.Models.DTOs;

public class AccountDTO
{
    public int Id { get; set; }
    public string AccountName { get; set; } = default!;
    public decimal TotalValueEur { get; set; }
}
