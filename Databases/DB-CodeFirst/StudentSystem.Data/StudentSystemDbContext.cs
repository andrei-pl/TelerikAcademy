namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystem.Model;
    using StudentSystem.Data.Migrations;
    public class StudentSystemDbContext : DbContext, IStudentSystemDBContext
    {
        public StudentSystemDbContext()
            :base("StudentSystem2")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }
        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Test> Tests { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .Property(s => s.FirstName)
                .IsUnicode();

            base.OnModelCreating(modelBuilder);
        }
    }
}
