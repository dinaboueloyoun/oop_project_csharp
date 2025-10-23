using System;
using System.Collections.Generic;
using System.Linq;

namespace ExaminationSystem
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public int CorrectAnswerId { get; set; }

        protected Question(string header, string body, double mark)
        {
            Header = header ?? throw new ArgumentNullException(nameof(header));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Mark = mark;
        }

        public abstract int DisplayAndGetAnswer();

        public override string ToString() => $"{Header}\n{Body}\nMark: {Mark}";

        public virtual object Clone()
        {
            Question clone = (Question)this.MemberwiseClone();
            clone.Answers = Answers.Select(a => a.Clone()).ToList();
            return clone;
        }

        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            int markCompare = Mark.CompareTo(other.Mark);
            if (markCompare != 0) return markCompare;
            return string.Compare(Header, other.Header, StringComparison.Ordinal);
        }
    }
}
