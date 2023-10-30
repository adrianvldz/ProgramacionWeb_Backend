using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Web_24BM.Models;

namespace Repository.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Persona> personas { get; set; }

        public virtual DbSet<Curriculum> Curriculums { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}