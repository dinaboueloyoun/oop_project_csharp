using System;

namespace ExaminationSystem
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam? ExamOfSubject { get; set; }

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }

        public void CreateExam(Exam exam) => ExamOfSubject = exam;

        public override string ToString() =>
            $"[{SubjectId}] {SubjectName} - Exam: {(ExamOfSubject != null ? ExamOfSubject.Title : "No Exam")}";
    }
}
