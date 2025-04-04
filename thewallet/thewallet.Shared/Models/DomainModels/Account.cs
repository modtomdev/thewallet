namespace thewallet.Shared.Models.DomainModels;

public class Account
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

}
