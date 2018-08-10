namespace ASP.NET_Core_Api.Controllers
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Domain;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TeacherController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TeacherController(ApplicationDbContext context) => this.context = context;

        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return context.Teacher.ToList();
        }

        [HttpGet("{id}", Name = "teacherById")]
        public IActionResult GetById(int id)
        {
            var teacher = context.Teacher.Include(t => t.Subjects).FirstOrDefault(x => x.TeacherId == id);

            if (teacher == null) return NotFound();

            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Teacher teacher)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.Teacher.Add(teacher);
            context.SaveChanges();

            return new CreatedAtRouteResult("teacherById", new {id = teacher.TeacherId}, teacher);
        }

        [HttpPut("{id}")]
        public IActionResult Post([FromBody] Teacher teacher, int id)
        {
            if (teacher.TeacherId != id || !ModelState.IsValid) return BadRequest();

            context.Entry(teacher).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = context.Teacher.FirstOrDefault(x => x.TeacherId == id);

            if (teacher == null) return NotFound();

            context.Teacher.Remove(teacher);
            context.SaveChanges();

            return Ok(teacher);
        }
    }
}