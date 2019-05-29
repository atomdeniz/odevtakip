using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Data.Model
{
    public class Homework: ModelBase
    {

        public Homework()
        {
            Files = new List<File>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Lesson Lesson { get; set; }

        public int LessonId { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
