namespace AspNetCore.Domain
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class MainDbContext : IdentityDbContext<ApplicationUser>
    {
        public MainDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
    }
}
