using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Data.Model
{
    public class Lesson : ModelBase
    {
        public Lesson()
        {
            StudentLessons = new List<StudentLesson>();
            Homeworks = new List<Homework>();
        }
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string Name { get; set; }
        public string Period { get; set; }
        public string Year { get; set; }
        public virtual ICollection<StudentLesson> StudentLessons { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
