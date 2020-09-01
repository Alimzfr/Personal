using Alimzfr.DomainLayer;
using Alimzfr.DomainLayer.AuthEntities;
using Alimzfr.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alimzfr.DataLayer.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option): base(option)
        {
        }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<TrainingCourse> TrainingCourses { get; set; }
        public DbSet<CollegeEducation> CollegeEducations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // it should be placed here, otherwise it will rewrite the following settings!
            base.OnModelCreating(builder);

            // Custom application mappings
            builder.EntitiesConfiguration();
        }
    }
}
