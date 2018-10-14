namespace AspNetCore.Data
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : MainDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
