using System;
using System.Collections.Generic;

namespace Z2
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted => DateCompleted.HasValue;

        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public TodoItem(string text)
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            Text = text;
        }

        public bool MarkAsCompleted()
        {
            if (IsCompleted) return false;
            DateCompleted = DateTime.Now;
            return true;
        }

        public override bool Equals(object obj)
        {
            var item = obj as TodoItem;
            return item != null &&
                   Id.Equals(item.Id) &&
                   Text == item.Text &&
                   IsCompleted == item.IsCompleted &&
                   EqualityComparer<DateTime?>.Default.Equals(DateCompleted, item.DateCompleted) &&
                   DateCreated == item.DateCreated;
        }

        public override int GetHashCode()
        {
            var hashCode = -555332867;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 + IsCompleted.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime?>.Default.GetHashCode(DateCompleted);
            hashCode = hashCode * -1521134295 + DateCreated.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(TodoItem i1, TodoItem i2)
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

        public static bool operator !=(TodoItem i1, TodoItem i2)
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
}
