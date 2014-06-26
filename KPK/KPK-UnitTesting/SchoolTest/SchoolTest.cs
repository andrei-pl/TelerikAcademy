namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestNewSchoolConstructorName()
        {
            string name = "TU-Sofia";
            School school = new School(name);
            Assert.AreEqual(school.Name, name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNewSchoolConstructorNullName()
        {
            string name = null;
            School school = new School(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNewSchoolConstructorEmptyName()
        {
            string name = string.Empty;
            School school = new School(name);
        }

        [TestMethod]
        public void TestAddStudentName()
        {
            string name = "TU-Sofia";
            Student student = new Student("Ivan Ivanov", 12233);
            School school = new School(name);
            school.AddStudent(student);
            Assert.AreEqual(student.Name, school.StudentsList[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistStudent()
        {
            string name = "TU-Sofia";
            Student student = new Student("Ivan Ivanov", 12233);
            Student student2 = new Student("Ivan Ivanov", 12233);
            School school = new School(name);
            school.AddStudent(student);
            school.AddStudent(student2);
        }

        [TestMethod]
        public void TestAddStudentId()
        {
            string name = "TU-Sofia";
            Student student = new Student("Ivan Ivanov", 12233);
            School school = new School(name);
            school.AddStudent(student);
            Assert.AreEqual(student.StudentId, school.StudentsList[0].StudentId);
        }

        [TestMethod]
        public void TestRemoveStudent()
        {
            string name = "4TU-Sofia";
            Student student = new Student("Ivan Ivanov", 12233);
            School school = new School(name);
            school.AddStudent(student);
            school.RemoveStudent(student);
            Assert.IsTrue(school.StudentsList.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveNotAddedStudent()
        {
            string name = "TU-Sofia";
            Student student = new Student("Ivan Ivanov", 12233);
            School school = new School(name);
            school.RemoveStudent(student);
        }
    }
}
