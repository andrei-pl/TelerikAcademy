namespace StudentSystem.Data.Repositories
{
    using System;
    using System.Linq;

    using StudentSystem.Model;

    public class StudentsRepository : GenericRepository<Student>
    {

        public StudentsRepository(IStudentSystemDBContext context) : base(context)
        {
        }

        public IQueryable<Student> AllAssistants()
        {
            return Search(s => s.Trainees.Count() > 0);
        }
    }
}
