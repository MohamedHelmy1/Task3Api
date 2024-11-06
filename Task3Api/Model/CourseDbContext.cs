using Microsoft.EntityFrameworkCore;

namespace Task3Api.Model
{
    public class CourseDbContext:DbContext
    {
        public CourseDbContext()
        {
                
        }
        public CourseDbContext(DbContextOptions<CourseDbContext>options):base(options) { }
        public virtual DbSet<courses> Courses { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<courses>(entity => entity.HasKey(x => x.ID));
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
