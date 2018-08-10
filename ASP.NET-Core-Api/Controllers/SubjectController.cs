using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Api.Controllers
{
    using Domain;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/Teacher/{TeacherId}/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public SubjectController(ApplicationDbContext context) => this.context = context;

        [HttpGet]
        public IEnumerable<Subject> GetAll(int TeacherId)
        {
            return context.Subject.Where(x => x.SubjectId == TeacherId).ToList();
        }

        [HttpGet("{id}", Name = "subjectById")]
        public IActionResult GetById(int id)
        {
            var subject = context.Subject.FirstOrDefault(x => x.SubjectId == id);

            if (subject == null) return NotFound();

            return new ObjectResult(subject);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Subject subject, int TeacherId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            subject.TeacherId = TeacherId;

            context.Subject.Add(subject);
            context.SaveChanges();

            return new CreatedAtRouteResult("subjectById", new { id = subject.SubjectId }, subject);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Subject subject, int id)
        {
            if (subject.SubjectId != id || !ModelState.IsValid) return BadRequest();

            context.Entry(subject).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var subject = context.Subject.FirstOrDefault(x => x.SubjectId == id);

            if (subject == null) return NotFound();

            context.Subject.Remove(subject);
            context.SaveChanges();

            return Ok(subject);
        }
    }
}