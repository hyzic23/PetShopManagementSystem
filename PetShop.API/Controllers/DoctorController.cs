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
    public class DoctorController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DoctorController(IUnitOfWork unitOfWork, 
                            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllDoctors")]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await unitOfWork.Doctors.GetAllAsync();
            var doctorDtos = mapper.Map<IEnumerable<DoctorDto>>(doctors);
            return Ok (doctorDtos);
        }

        [HttpGet]
        [Route("GetDoctorsById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor == null) return Ok();
            return Ok(doctor);
        }

        [HttpPost]
        [Route("AddDoctor")]
        public async Task<IActionResult> Add(DoctorDto doctorDto)
        {
            var doctor = mapper.Map<Doctor>(doctorDto);
            var data = await unitOfWork.Doctors.AddAsync(doctor);
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteDoctor")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Doctors.DeleteAsync(id);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateDoctor")]
        public async Task<IActionResult> Update(DoctorDto doctorDto)
        {
            var doctor = mapper.Map<Doctor>(doctorDto);
            var data = await unitOfWork.Doctors.UpdateAsync(doctor);
            return Ok(data);
        }
    



    }



}