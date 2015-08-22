using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class Discipline : IComments
    {
        public string DisciplineName { get; set; }
       
        public int NumberOfLectures { get; set; }
       
        public int NumberOfExercises { get; set; }

        public Discipline(string disciplineName, int numberOfLectures, int numberOfExercises)
        {
            DisciplineName = disciplineName;
            NumberOfLectures = numberOfLectures;
            NumberOfExercises = numberOfExercises;
        }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
