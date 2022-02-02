using AutoMapper;
using PetShop.Core.Models;
using PetShop.Infrastructure.Dtos;

namespace PetShop.Infrastructure.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
             CreateMap<Pet, PetDto>().ReverseMap();
             CreateMap<Doctor, DoctorDto>().ReverseMap();
             CreateMap<BookVetAppointment, BookVetAppointmentDto>().ReverseMap();
        }
    }
}