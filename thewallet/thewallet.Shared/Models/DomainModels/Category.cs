namespace thewallet.Shared.Models.DomainModels;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int UserId { get; set; }
    public bool IsExpense { get; set; }
    public DateTime CreatedAt { get; set; }
    public required User Owner { get; set; }
}
