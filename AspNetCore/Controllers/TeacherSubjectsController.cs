namespace AspNetCore.Controllers
{
    using Data;
    using Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeacherSubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherSubjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherSubjects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherSubjects.Include(t => t.Subject).Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherSubject = await _context.TeacherSubjects
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherSubjectId == id);
            if (teacherSubject == null)
            {
                return NotFound();
            }

            return View(teacherSubject);
        }

        // GET: TeacherSubjects/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name");
            return View();
        }

        // POST: TeacherSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherSubjectId,TeacherId,SubjectId")] TeacherSubject teacherSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", teacherSubject.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name", teacherSubject.TeacherId);
            return View(teacherSubject);
        }

        // GET: TeacherSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherSubject = await _context.TeacherSubjects.FindAsync(id);
            if (teacherSubject == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", teacherSubject.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name", teacherSubject.TeacherId);
            return View(teacherSubject);
        }

        // POST: TeacherSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherSubjectId,TeacherId,SubjectId")] TeacherSubject teacherSubject)
        {
            if (id != teacherSubject.TeacherSubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherSubjectExists(teacherSubject.TeacherSubjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", teacherSubject.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name", teacherSubject.TeacherId);
            return View(teacherSubject);
        }

        // GET: TeacherSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherSubject = await _context.TeacherSubjects
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherSubjectId == id);
            if (teacherSubject == null)
            {
                return NotFound();
            }

            return View(teacherSubject);
        }

        // POST: TeacherSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherSubject = await _context.TeacherSubjects.FindAsync(id);
            _context.TeacherSubjects.Remove(teacherSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherSubjectExists(int id)
        {
            return _context.TeacherSubjects.Any(e => e.TeacherSubjectId == id);
        }
    }
}
