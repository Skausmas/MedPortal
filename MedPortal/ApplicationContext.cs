using Microsoft.EntityFrameworkCore;
namespace MedPortal
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; } = null!;
        public DbSet<Doctors> Doctors { get; set; } = null!;
        public DbSet<History> History { get; set; } = null!;
        public DbSet<Registration> Registration { get; set; } = null!;
        public DbSet<Specialization> Specialization { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }
    }
}
