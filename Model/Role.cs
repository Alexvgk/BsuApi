using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Model
{
    public class Role : BaseModel
    {
        public string? UserRole { get; set;}
        public virtual  List<User>? Users { get; set;}
    }
}
