using System;
using System.Collections.Generic;

namespace ExaminationSystem
{
    public class PracticalExam : Exam
    {
        public PracticalExam(string title, TimeSpan timeOfExam) : base(title, timeOfExam) { }

        public override void ShowExam()
        {
            UI.ClearAndDrawHeader($"Practical Exam: {Title}", $"Duration: {TimeOfExam}");
            var userAnswers = new Dictionary<Question, int>();
            foreach (var q in Questions)
            {
                int chosenId = q.DisplayAndGetAnswer();
                userAnswers[q] = chosenId;
                Console.WriteLine();
            }

            UI.ShowSuccess("Exam finished. Correct answers are shown below.");
            foreach (var q in Questions)
            {
                UI.DrawLine();
                Console.WriteLine(q.ToString());
                foreach (var a in q.Answers) Console.WriteLine(a.ToString());
                Console.WriteLine($"Correct: {q.CorrectAnswerId}   Your: {userAnswers[q]}");
            }
            UI.Pause();
        }
    }
}
