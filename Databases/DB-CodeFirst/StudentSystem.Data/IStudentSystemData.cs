using StudentSystem.Data.Repositories;
using StudentSystem.Model;
using System;
namespace StudentSystem.Data
{
    public interface IStudentSystemData
    {
        IGenericRepository<Course> Courses { get; }
        StudentsRepository Students { get; }
    }
}
