using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Interfaces;
using PetShop.Core.Models;
using PetShop.Infrastructure.Dtos;
using PetShop.Infrastructure.Validators;

namespace PetShop.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class PetController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PetController(IUnitOfWork unitOfWork, 
                            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllPets")]
        public async Task<IActionResult> GetAll()
        {
            var pets = await unitOfWork.Pets.GetAllAsync();
            var petDtos = mapper.Map<IEnumerable<PetDto>>(pets);
            return Ok (petDtos);
        }

        [HttpGet]
        [Route("GetPetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Pets.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPost]
        [Route("AddPet")]
        public async Task<IActionResult> Add(PetDto petDto)
        {
            var pet = mapper.Map<Pet>(petDto);
            var data = await unitOfWork.Pets.AddAsync(pet);
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeletePet")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Pets.DeleteAsync(id);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdatePet")]
        public async Task<IActionResult> Update(Pet pet)
        {
            var data = await unitOfWork.Pets.UpdateAsync(pet);
            return Ok(data);
        }
    



    }
}