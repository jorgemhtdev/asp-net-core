namespace ASP.NET_Core_Backend.Models
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContextBackend : ApplicationDbContext
    {
        public ApplicationDbContextBackend(DbContextOptions<ApplicationDbContextBackend> options) : base(options) { }
    }
}
