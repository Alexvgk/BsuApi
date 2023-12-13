using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Role : BaseModel
    {
        public string? UserRole { get; set;}
        public  List<User>? users { get; set;}
    }
}
