using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Model
{
    public class CourseGroup : BaseModel
    {
        public string? Course { get; set;}
        public string? Group { get; set;}
        public string? Speciality { get; set; }
        public virtual List<Schedule>? Schedules { get; set;}
        public virtual List<User>? Users { get; set; }
        public virtual List<News>? News { get; set; }
    }
}
