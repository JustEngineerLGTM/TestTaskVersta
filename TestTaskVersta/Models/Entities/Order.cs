namespace TestTaskVersta.Models.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string OrderNumber { get; private set; } =
        "ORD-" + Guid.NewGuid().ToString("N")[..4].ToUpper();

    public string SenderCity { get; set; } = string.Empty;
    public string SenderAddress { get; set; } = string.Empty;
    public string ReceiverCity { get; set; } = string.Empty;
    public string ReceiverAddress { get; set; } = string.Empty;
    public double Weight { get; set; }
    public DateTime PickupDate { get; set; }
}