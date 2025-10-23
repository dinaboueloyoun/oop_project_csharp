using System;
using System.Collections.Generic;
using System.Linq;

namespace ExaminationSystem
{
    public class McqQuestion : Question
    {
        public McqQuestion(string header, string body, double mark, IEnumerable<Answer> answers)
            : base(header, body, mark)
        {
            Answers = answers.Select(a => new Answer(a.AnswerId, a.AnswerText)).ToList();
        }

        public override int DisplayAndGetAnswer()
        {
            UI.DrawLine();
            UI.WriteCentered("MCQ", ConsoleColor.DarkYellow);
            Console.WriteLine(ToString());
            foreach (var a in Answers) Console.WriteLine(a.ToString());
            Console.WriteLine();
            int choice = InputHelper.ReadIntInRange($"Choose (1-{Answers.Count}): ", Answers.First().AnswerId, Answers.Last().AnswerId);
            return choice;
        }

        public override object Clone() => base.Clone();
    }
}
