🧠 Examination System – C# OOP Project

By DINA ABOU ELOYOUN

📘 Overview

This project is a Console-Based Examination System built using Object-Oriented Programming (OOP) concepts in C#.
It simulates a real examination process, allowing the creation of different types of exams and questions, with automatic result calculation and flexible exam display behavior.

🎯 Objectives

The system was developed to demonstrate key OOP principles such as:

Inheritance

Polymorphism

Encapsulation

Interface Implementation (ICloneable, IComparable)

Constructor Chaining & Overriding (ToString)

🏗️ System Design
🔹 Question Hierarchy

Base Class: Question → contains Header, Body, and Mark.

Derived Classes:

TrueFalseQuestion

McqQuestion

🔹 Exam Types

Base Class: Exam → defines Time, Number of Questions, and ShowExam() method.

Derived Classes:

FinalExam → Displays questions, answers, and total grade.

PracticalExam → Displays right answers after submission.

🔹 Supporting Classes

Answer → represents each answer option (ID, Text).

Subject → holds Subject ID, Name, and related Exam.

⚙️ Features

✅ Create different types of exams (Final / Practical).
✅ Support for True/False and MCQ questions.
✅ Automatic grade calculation.
✅ Show correct answers after the exam (for Practical).
✅ Apply OOP design principles for scalability and clean structure.

🧩 Technologies Used

Language: C#

Framework: .NET (Console Application)

Paradigm: Object-Oriented Programming
