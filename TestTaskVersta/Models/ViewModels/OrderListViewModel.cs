namespace TestTaskVersta.Models.ViewModels;

public class OrderListViewModel
{
    public Guid Id { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public string SenderCity { get; set; } = string.Empty;

    public string SenderAddress { get; set; } = string.Empty;

    public string ReceiverCity { get; set; } = string.Empty;

    public string ReceiverAddress { get; set; } = string.Empty;

    public double Weight { get; set; }

    public DateTime PickupDate { get; set; }
}