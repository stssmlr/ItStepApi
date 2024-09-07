using Microsoft.AspNetCore.Mvc;
using Data.Entities;
using Data.Data;

namespace itstep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly ITStepDbContext ctx;

        public EducationController(ITStepDbContext ctx)
        {
            this.ctx = ctx;
        }

        // [C]reate [R]ead [U]pdate [D]elete

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(ctx.Educations.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = ctx.Educations.Find(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Education model)
        {
            if (!ModelState.IsValid) return BadRequest();

            ctx.Educations.Add(model);
            ctx.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Education model)
        {
            if (!ModelState.IsValid) return BadRequest();

            ctx.Educations.Update(model);
            ctx.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = ctx.Educations.Find(id);
            if (product == null) return NotFound();

            ctx.Educations.Remove(product);
            ctx.SaveChanges();

            return Ok();
        }
    }
}

