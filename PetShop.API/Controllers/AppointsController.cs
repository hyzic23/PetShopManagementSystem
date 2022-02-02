using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Interfaces;
using PetShop.Core.Models;
using PetShop.Infrastructure.Dtos;

namespace PetShop.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AppointsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AppointsController(IUnitOfWork unitOfWork, 
                                  IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllAppoints")]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await unitOfWork.Appointments.GetAllAppointments();
            var appointmentDtos = mapper.Map<IEnumerable<BookVetAppointmentDto>>(appointments);
            return Ok (appointmentDtos);
        }


        [HttpPost]
        [Route("BookAppointment")]
        public async Task<IActionResult> Add(BookVetAppointmentDto request)
        {
            var appointment = mapper.Map<BookVetAppointment>(request);
            var data = await unitOfWork.Appointments.BookAppointment(appointment);
            return Ok(data);
        }


    }
}