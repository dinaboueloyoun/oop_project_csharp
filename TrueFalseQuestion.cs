using System;

namespace ExaminationSystem
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, double mark)
            : base(header, body, mark)
        {
            Answers = new List<Answer> { new Answer(1, "True"), new Answer(2, "False") };
        }

        public override int DisplayAndGetAnswer()
        {
            UI.DrawLine();
            UI.WriteCentered("TRUE / FALSE", ConsoleColor.DarkYellow);
            Console.WriteLine(ToString());
            foreach (var a in Answers) Console.WriteLine(a.ToString());
            Console.WriteLine();
            int choice = InputHelper.ReadIntInRange("Choose (1-2): ", 1, 2);
            return choice;
        }

        public override object Clone() => base.Clone();
    }
}
