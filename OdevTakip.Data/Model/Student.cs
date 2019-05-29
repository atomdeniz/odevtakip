using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Data.Model
{
    public class Student : ModelBase
    {
        public Student()
        {
            StudentLessons = new List<StudentLesson>();
            Files = new List<File>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SchoolNumber { get; set; }
        public virtual ICollection<StudentLesson> StudentLessons { get; set; }
        public virtual ICollection<File> Files { get; set; }     
    }
}
