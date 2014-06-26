using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class Disciplines : IComments
    {
        public string DisciplineName { get; set; }
       
        public int NumberOfLectures { get; set; }
       
        public int NumberOfExercises { get; set; }

        public Disciplines(string disciplineName, int numberOfLectures, int numberOfExercises)
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
