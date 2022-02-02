using FluentValidation;
using PetShop.Infrastructure.Dtos;

namespace PetShop.Infrastructure.Validators
{
    public class PetsValidator : AbstractValidator<PetDto>
    {
        public PetsValidator()
        {
            RuleFor(P => P.PetName)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(P => P.PetType)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}