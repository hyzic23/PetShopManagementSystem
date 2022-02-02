using FluentValidation;
using PetShop.Infrastructure.Dtos;

namespace PetShop.Infrastructure.Validators
{
    public class DoctorsValidator : AbstractValidator<DoctorDto>
    {
        public DoctorsValidator()
        {
            RuleFor(P => P.DoctorName)
                .NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}