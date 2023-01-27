using FluentValidation;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Spare;


namespace oneparalyzer.ServiceCenter.UseCases.DTOs.Validation.Spare
{
    public class AddSpareValidator : AbstractValidator<AddSpareDTO>
    {
        public AddSpareValidator()
        {
            RuleFor(x => x.Device).NotEmpty().WithMessage("Укажите название устройства");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Укажите стоимость");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Укажите название");
        }
    }
}
