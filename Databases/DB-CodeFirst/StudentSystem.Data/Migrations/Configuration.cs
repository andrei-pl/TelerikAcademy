namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        Random rand;
        string[] names = new string[4] { "Doncho", "Niki", "Ivailo", "Evlogi" };
        string[] families = new string[4] { "Minkov", "Kostov", "Kenov", "Hristov" };

        public Configuration()
        {
            this.rand = new Random();
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            var count = rand.Next(0, 10);

            for (int i = 0; i <= count; i++)
            {
                SeedStudents(context, names[rand.Next(0, 4)], families[rand.Next(0, 4)], rand.Next(16, 65));
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private static void SeedStudents(StudentSystemDbContext context, string name, string family, int age)
        {
            if (context.Students.Any())
            {
                //return;
            }

            context.Students.Add(new Student
            {
                FirstName = name,
                LastName = family,
                Age = age,
                StudentInfo = new StudentInfo { Email = name + "@" + family + ".com" }
            });
        }
    }
}
