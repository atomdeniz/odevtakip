using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Data.Model
{
    public class Teacher : ModelBase
    {
        public Teacher()
        {
            Lessons = new List<Lesson>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
