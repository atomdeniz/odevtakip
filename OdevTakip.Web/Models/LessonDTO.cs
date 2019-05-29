using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdevTakip.Web.Models
{
    public class LessonDTO : BaseDto
    {
        public string Year { get; set; }

        public string Period { get; set; }

        public string Lesson { get; set; }
    }
}
