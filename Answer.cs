using System;

namespace ExaminationSystem
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text ?? throw new ArgumentNullException(nameof(text));
        }

        public override string ToString() => $"{AnswerId}. {AnswerText}";

        public Answer Clone() => new Answer(AnswerId, string.Copy(AnswerText));
    }
}
