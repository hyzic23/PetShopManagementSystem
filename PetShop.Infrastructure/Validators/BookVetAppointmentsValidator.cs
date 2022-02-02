using FluentValidation;
using PetShop.Infrastructure.Dtos;

namespace PetShop.Infrastructure.Validators
{
    public class BookVetAppointmentsValidator : AbstractValidator<BookVetAppointmentDto>
    {
        public BookVetAppointmentsValidator()
        {
            RuleFor(P => P.AppointmentDt)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(P => P.AppointmentDt)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(P => P.EmailAddress)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("A valid email address is required.");;

            RuleFor(P => P.phoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(P => P.PetsOwnerName)
                .NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}