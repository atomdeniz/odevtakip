using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Data.Model
{
    public class File : ModelBase
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public Student Student { get; set; }

        public int StudentId { get;set;}

        public Homework Homework { get; set; }

        public int HomeworkId { get; set; }



    }
}
