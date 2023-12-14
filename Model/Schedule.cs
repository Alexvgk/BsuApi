using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Schedule : BaseModel
    {
        public string? Name { get; set;}
        public string? Lecture { get; set;}
        public string? Classroom { get; set;}
        public string? Time { get; set;}
        public Guid? IdForm { get; set;}
        public Guid? CGId { get; set;}
        public Guid? DayId { get;set;}
        public virtual CourseGroup? CorseGroups { get; set;}
        public virtual LessonForm? LessonForms { get; set;}  
        public virtual DayTime? DayTimes { get; set;}    
    }
}
