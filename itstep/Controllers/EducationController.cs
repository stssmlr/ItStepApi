using Microsoft.AspNetCore.Mvc;
using Data.Entities;
using Data.Data;
using AutoMapper;
using Core.Dtos;
using Core.Interfaces;

namespace itstep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService educationService;

        public EducationController(IEducationService educationService)
        {
            this.educationService = educationService;
        }

        // [C]reate [R]ead [U]pdate [D]elete

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await educationService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await educationService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEducationDto model)
        {
            await educationService.Create(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditEducationDto model)
        {
            await educationService.Edit(model);

            return Ok();
        }
        [HttpPatch("archive")]
        public async Task<IActionResult> Archive(int id)
        {
            await educationService.Archive(id);

            return Ok();
        }

        [HttpPatch("restore")]
        public async Task<IActionResult> Restore(int id)
        {
            await educationService.Restore(id);

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await educationService.Delete(id);

            return Ok();
        }
    }
}

