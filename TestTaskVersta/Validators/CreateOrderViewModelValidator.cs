using FluentValidation;
using TestTaskVersta.Models.ViewModels;

namespace TestTaskVersta.Validators
{
    public class CreateOrderViewModelValidator : AbstractValidator<CreateOrderViewModel>
    {
        public CreateOrderViewModelValidator()
        {
            RuleFor(x => x.SenderCity)
                .NotEmpty().WithMessage("Город отправителя обязателен.")
                .MaximumLength(100).WithMessage("Город отправителя не должен превышать 100 символов.");

            RuleFor(x => x.SenderAddress)
                .NotEmpty().WithMessage("Адрес отправителя обязателен.")
                .MaximumLength(200).WithMessage("Адрес отправителя не должен превышать 200 символов.");

            RuleFor(x => x.ReceiverCity)
                .NotEmpty().WithMessage("Город получателя обязателен.")
                .MaximumLength(100).WithMessage("Город получателя не должен превышать 100 символов.");

            RuleFor(x => x.ReceiverAddress)
                .NotEmpty().WithMessage("Адрес получателя обязателен.")
                .MaximumLength(200).WithMessage("Адрес получателя не должен превышать 200 символов.");

            RuleFor(x => x.Weight)
                .GreaterThan(0).WithMessage("Вес груза должен быть больше нуля.");

            RuleFor(x => x.PickupDate)
                .NotEmpty().WithMessage("Дата забора груза обязательна.")
                .Must(BeAValidDate).WithMessage("Некорректная дата.");
        }

        private static bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default);
        }
    }
}
