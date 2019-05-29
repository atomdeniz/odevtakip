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
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SchoolNumber { get; set; }
        public virtual ICollection<StudentLesson> StudentLessons { get; set; }

        // Fluently bir şekilde ilişkileri kullanabilmemiz için tanımlıyoruz.
        //public virtual ICollection<Article> Articles { get; set; }
    }
}
