using Model;
using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DayTime : BaseModel
    {
        public string? Day { get; set; }
        public virtual List<Schedule>? Schedules { get; set;}

    }
}
