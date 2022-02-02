using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.Interfaces;
using PetShop.Infrastructure.Dtos;
using PetShop.Infrastructure.Helpers;
using PetShop.Infrastructure.Repository;
using PetShop.Infrastructure.Validators;

namespace PetShop.API.Extension
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            //services.AddControllers()
            //    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PetDto>());
            
            
            
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddFluentValidation(x =>
            {
                //x.DisableDataAnnotationsValidation = true;
                //x.ImplicitlyValidateChildProperties = true;
                x.RegisterValidatorsFromAssemblyContaining<PetsValidator>();
                x.RegisterValidatorsFromAssemblyContaining<DoctorsValidator>();
            });
            
        }
    }
}