﻿using Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class News : BaseModel
    {
        public string? Text { get; set; }
        public byte[]? ImageData { get; set; }
        public Guid CourseGroupId { get; set; }
        public virtual CourseGroup? CourseGroup { get; set; } 
    }
}
