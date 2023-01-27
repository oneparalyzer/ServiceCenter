using FluentValidation;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;

namespace oneparalyzer.ServiceCenter.UseCases.DTOs.Validation.Service
{
    public class UpdateServiceValidator : AbstractValidator<UpdateServiceDTO>
    {
        public UpdateServiceValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().WithMessage("Укажите название");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Укажите стоимость");
        }
    }
}
