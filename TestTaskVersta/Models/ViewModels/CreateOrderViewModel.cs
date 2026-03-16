using System.ComponentModel.DataAnnotations;

namespace TestTaskVersta.Models.ViewModels;

public class CreateOrderViewModel
{
    [Display(Name = "Город отправителя")]
    [Required(ErrorMessage = "Город отправителя обязателен")]
    public string SenderCity { get; set; } = string.Empty;

    [Display(Name = "Адрес отправителя")]
    [Required(ErrorMessage = "Адрес отправителя обязателен")]
    public string SenderAddress { get; set; } = string.Empty;

    [Display(Name = "Город получателя")]
    [Required(ErrorMessage = "Город получателя обязателен")]
    public string ReceiverCity { get; set; } = string.Empty;

    [Display(Name = "Адрес получателя")]
    [Required(ErrorMessage = "Адрес получателя обязателен")]
    public string ReceiverAddress { get; set; } = string.Empty;

    [Display(Name = "Вес груза")]
    [Required(ErrorMessage = "Вес груза обязателен")]
    [Range(0.01, 100000, ErrorMessage = "Вес должен быть больше 0 и меньше 100000")]
    public double Weight { get; set; }

    [Display(Name = "Дата забора")]
    [Required(ErrorMessage = "Введите правильную дату забора")]
    public DateTime PickupDate { get; set; }
}
