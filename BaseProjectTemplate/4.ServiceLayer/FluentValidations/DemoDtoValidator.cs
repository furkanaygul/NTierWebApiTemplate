using BaseProjectTemplate._4.ServiceLayer.DTOs;
using FluentValidation;

namespace BaseProjectTemplate._4.ServiceLayer.FluentValidations
{
    public class DemoDtoValidator: AbstractValidator<DemoDto>
    {
        public DemoDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
        }
    }
   
}
