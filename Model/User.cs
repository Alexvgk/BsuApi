﻿using Model.Base;

namespace Model
{
    [Serializable]
    public class User : BaseModel, IEquatable<User>
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? Email { get; set;}
        public string? Password { get; set;}
        public byte[]? Photo { get; set;}
        public Guid? IdCourseGroup { get; set;}
        public Guid? IdRole { get; set; }
        public virtual CourseGroup? CorseGroup { get; set; }
        public virtual Role? Roles { get; set; }
        public virtual List<UID>? UIDs { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   FirstName == other.FirstName &&
                   SecondName == other.SecondName &&
                   Email == other.Email;
        }

        public override int GetHashCode()
        {
            int hashCode = 741780372;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SecondName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            return hashCode;
        }
    }
}
