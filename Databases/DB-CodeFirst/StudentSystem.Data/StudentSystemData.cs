﻿namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;

    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;
    public class StudentSystemData : IStudentSystemData
    {
        private IStudentSystemDBContext context;
        private IDictionary<Type, object> repositories;

        public StudentSystemData()
            : this(new StudentSystemDbContext())
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public StudentSystemData(IStudentSystemDBContext context)
        {
            this.context = context;
        }

        public IGenericRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public StudentsRepository Students
        {
            get
            {
                return (StudentsRepository)this.GetRepository<Student>();
            }
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(IGenericRepository<T>);
                if (typeOfModel.IsAssignableFrom(typeof(Student)))
                {
                    typeOfRepository = typeof(StudentsRepository);
                }

                var newRepository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(typeOfModel, newRepository);
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
