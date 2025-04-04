namespace thewallet.Shared.Models.DomainModels;

public class RecurringTransaction
{
    public int Id { get; set; } 
    public required string Frequency { get; set; } //daily, weekly, monthly, yearly
    public DateTime DesiredDate { get; set; } 
    public DateTime CreatedAt { get; set; } 
    public int AssetHoldingId { get; set; } 
    public decimal Quantity { get; set; }
}