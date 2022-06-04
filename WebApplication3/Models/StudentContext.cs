using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace WebApplication3.Models
{
    public class StudentContext: IdentityDbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options){}
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
