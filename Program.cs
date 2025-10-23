using System;
using System.Collections.Generic;
using System.Threading;

namespace ExaminationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.SetTitle("Examination System - DINA ABOU ELOYOUN");

            bool repeat = true;
            while (repeat)
            {
                UI.ClearAndDrawHeader("Welcome to Examination System", "by DINA ABOU ELOYOUN");
                UI.WriteBox("Quick Guide", new[]
                {
                    "• You will create a Subject and an Exam (Final or Practical).",
                    "• Supported question types: True/False and MCQ.",
                    "• Input is validated. If you enter wrong type, you will be asked again.",
                    "• Practical shows correct answers after finishing.",
                    "• Final shows total grade and detailed report."
                }, ConsoleColor.DarkCyan);

                Console.WriteLine();
                string subjectName = InputHelper.ReadNonEmptyString("Enter Subject Name: ", forbidNumeric: true);
                var subject = new Subject(1, subjectName);

                Console.WriteLine();
                Console.WriteLine("Choose Exam Type:");
                Console.WriteLine("1. Final Exam");
                Console.WriteLine("2. Practical Exam");
                int examType = InputHelper.ReadIntInRange(">> ", 1, 2);

                Exam exam = examType == 1
                    ? new FinalExam("Final Exam", TimeSpan.FromMinutes(InputHelper.ReadIntInRange("Exam duration (minutes): ", 10, 300)))
                    : new PracticalExam("Practical Exam", TimeSpan.FromMinutes(InputHelper.ReadIntInRange("Exam duration (minutes): ", 10, 300)));

                Console.WriteLine();
                int qCount = InputHelper.ReadIntInRange("How many questions? (1-100): ", 1, 100);
                for (int i = 1; i <= qCount; i++)
                {
                    UI.ClearAndDrawHeader($"Question Setup ({i}/{qCount})");
                    string header = InputHelper.ReadNonEmptyString("Header: ", forbidNumeric: true);
                    string body = InputHelper.ReadNonEmptyString("Body: ", forbidNumeric: false);
                    double mark = InputHelper.ReadDoubleNonNegative("Mark (e.g. 2.5): ");

                    Console.WriteLine("Question Type:");
                    Console.WriteLine("1. True/False");
                    Console.WriteLine("2. MCQ");
                    int qType = InputHelper.ReadIntInRange(">> ", 1, 2);

                    Question q;
                    if (qType == 1)
                    {
                        q = new TrueFalseQuestion(header, body, mark);
                        int correct = InputHelper.ReadIntInRange("Correct answer (1=True, 2=False): ", 1, 2);
                        q.CorrectAnswerId = correct;
                    }
                    else
                    {
                        int options = InputHelper.ReadIntInRange("Number of options (2-10): ", 2, 10);
                        var answers = new List<Answer>();
                        for (int k = 1; k <= options; k++)
                        {
                            string aText = InputHelper.ReadNonEmptyString($"Option {k}: ", forbidNumeric: false);
                            answers.Add(new Answer(k, aText));
                        }
                        q = new McqQuestion(header, body, mark, answers);
                        int correct = InputHelper.ReadIntInRange($"Correct answer (1-{options}): ", 1, options);
                        q.CorrectAnswerId = correct;
                    }

                    exam.AddQuestion(q);
                    UI.ShowSuccess($"Question {i} added.");
                    Thread.Sleep(400);
                }

                subject.CreateExam(exam);
                UI.ClearAndDrawHeader("Exam Ready", subject.ToString());
                UI.ShowSuccess("Exam created successfully!");

                Console.WriteLine();
                Console.WriteLine("Do you want to start the exam now?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No (Exit)");
                int start = InputHelper.ReadIntInRange(">> ", 1, 2);
                if (start == 1)
                    subject.ExamOfSubject?.ShowExam();
                else
                    UI.ShowWarning("Exiting without starting the exam.");

                UI.DrawLine();
                UI.WriteCentered("Thank you for using Examination System", ConsoleColor.Cyan);
                UI.Pause();

                // 🔹 هنا الجزء الجديد بعد انتهاء الامتحان 🔹
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nWould you like to create another exam? (y/n): ");
                string again = Console.ReadLine().ToLower();

                if (again != "y")
                {
                    repeat = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nGoodbye! 👋");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
