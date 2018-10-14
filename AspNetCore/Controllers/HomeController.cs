namespace AspNetCore.Controllers
{
    using Data;
    using Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (await _context.Students.CountAsync() != 0) return View();

            await _context.Students.AddRangeAsync(LoadedStudent());
            await _context.Teachers.AddRangeAsync(LoadedTeacher());
            await _context.Subjects.AddRangeAsync(LoadedSubject());

            await _context.SaveChangesAsync();

            return View();
        }

        private IList<Student> LoadedStudent()
        {
            return new List<Student>()
            {
                new Student {Name = "Jennifer Aniston", Age = 23},
                new Student {Name = "Courteney Cox ", Age = 23},
                new Student {Name = "Lisa Kudrow ", Age = 21},
                new Student {Name = "Matt LeBlanc", Age = 25},
                new Student {Name = "Matthew Perry ", Age = 25},
                new Student {Name = "David Schwimmer", Age = 22},
                new Student {Name = "James Michael Tyler", Age = 25},
                new Student {Name = "Maggie Wheeler", Age = 21}
            };
        }

        private IList<Teacher> LoadedTeacher()
        {
            return new List<Teacher>()
            {
                new Teacher {Name = "Rachel Green", Age = 24},
                new Teacher {Name = "Monica Geller", Age = 65},
                new Teacher {Name = "Phoebe Buffay", Age = 44},
                new Teacher {Name = "Joey Tribbiani", Age = 56},
                new Teacher {Name = "Chandler Muriel Bing", Age = 36},
                new Teacher {Name = "Ross Geller", Age = 54},
                new Teacher {Name = "Gunther", Age = 43},
                new Teacher {Name = "Janice Litman Goralnik", Age = 62}
            };
        }

        private IList<Subject> LoadedSubject()
        {
            return new List<Subject>()
            {
                new Subject {Name = "Computer Science"},
                new Subject {Name = "Chemistry"},
                new Subject {Name = "Physical Education"},
                new Subject {Name = "Economics"},
                new Subject {Name = "History"},
                new Subject {Name = "Maths"},
                new Subject {Name = "Physics"}
            };
        }
    }
}