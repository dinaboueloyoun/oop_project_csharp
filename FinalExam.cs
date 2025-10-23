using System;
using System.Collections.Generic;
using System.Linq;

namespace ExaminationSystem
{
    public class FinalExam : Exam
    {
        public FinalExam(string title, TimeSpan timeOfExam) : base(title, timeOfExam) { }

        public override void ShowExam()
        {
            UI.ClearAndDrawHeader($"Final Exam: {Title}", $"Duration: {TimeOfExam}");
            double totalMark = Questions.Sum(q => q.Mark);
            double userMark = 0.0;
            var userAnswers = new Dictionary<Question, int>();

            foreach (var q in Questions)
            {
                int chosenId = q.DisplayAndGetAnswer();
                userAnswers[q] = chosenId;
                if (chosenId == q.CorrectAnswerId) userMark += q.Mark;
                Console.WriteLine();
            }

            UI.DrawLine();
            UI.WriteCentered("RESULT", ConsoleColor.Magenta, true);
            Console.WriteLine($"Total Marks: {totalMark}");
            Console.WriteLine($"Your Marks : {userMark}");
            double percent = totalMark == 0 ? 0 : (userMark / totalMark) * 100.0;
            Console.WriteLine($"Percentage : {percent:0.##}%");
            UI.DrawLine();

            Console.WriteLine("Questions & Answers:");
            foreach (var q in Questions)
            {
                Console.WriteLine(q.ToString());
                foreach (var a in q.Answers) Console.WriteLine(a.ToString());
                Console.WriteLine($"Correct: {q.CorrectAnswerId}   Your: {userAnswers[q]}");
            }
            UI.Pause();
        }
    }
}
