using System;
using System.Collections.Generic;
using System.Linq;

namespace ExaminationSystem
{
    public abstract class Exam : ICloneable
    {
        public TimeSpan TimeOfExam { get; set; }
        public int NumberOfQuestions => Questions.Count;
        public List<Question> Questions { get; set; } = new List<Question>();
        public string Title { get; set; }

        protected Exam(string title, TimeSpan timeOfExam)
        {
            Title = title;
            TimeOfExam = timeOfExam;
        }

        public void AddQuestion(Question q) => Questions.Add(q);
        public abstract void ShowExam();

        public override string ToString() => $"{Title} - Duration: {TimeOfExam} - Questions: {NumberOfQuestions}";

        public virtual object Clone()
        {
            Exam clone = (Exam)this.MemberwiseClone();
            clone.Questions = Questions.Select(q => (Question)q.Clone()).ToList();
            return clone;
        }
    }
}
