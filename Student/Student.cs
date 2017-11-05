namespace Z1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public Student(string name, string jmbag, Gender gender)
        {
            Name = name;
            Jmbag = jmbag;
            Gender = gender;
        }

        protected bool Equals(Student other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Jmbag, other.Jmbag) && Gender == other.Gender;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Student)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Jmbag != null ? Jmbag.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Gender;
                return hashCode;
            }
        }

        public static bool operator ==(Student i1, Student i2)
        {
            if (ReferenceEquals(i1, null) && ReferenceEquals(i2, null))
            {
                return true;
            }

            if (ReferenceEquals(i1, null) || ReferenceEquals(i2, null))
            {
                return false;
            }

            return i1.Equals(i2);
        }

        public static bool operator !=(Student i1, Student i2)
        {
            if (ReferenceEquals(i1, null) && ReferenceEquals(i2, null))
            {
                return false;
            }

            if (ReferenceEquals(i1, null) || ReferenceEquals(i2, null))
            {
                return true;
            }

            return !i1.Equals(i2);
        }
    }

    public enum Gender
    {
        Male, Female
    }
}
