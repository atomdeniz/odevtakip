﻿using OdevTakip.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Business.Services.Interfaces
{
    public interface ILessonService
    {
        void AddLesson(Lesson lesson);

        List<Lesson> LessonListForTeacher(string year,string period,int teacherId);

        List<Homework> GetHomeworksForLesson(int lessonid);

        void AddHomework(int lessonid, string name);
    }
}
