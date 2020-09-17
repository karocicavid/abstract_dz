﻿using System;
namespace cavid
{
    abstract class Given
    {
        public string Surname;
        public string Name;
        public int Course;
        public int Book_num;
        public Given() { }
        public Given(string surname, string name, int course, int book_num)
        {
            Surname = surname; Name = name; Course = course; Book_num = book_num;
        }
        public abstract void Call();
    }
    class Student : Given
    {
        public Student() { }
        public Student(string surname, string name, int course, int book_num)
            : base(surname, name, course, book_num) { }
        public override void Call()
        {
            Console.WriteLine($"\nStudent {Name} {Surname} study in {Course} course by grade book number {Book_num}");
            Console.Write("Если хотите продолжить нажмите 1,если нет нажмите 2 - ");
            string num = Console.ReadLine();
            if (num == "1")
            {
                Call call = new Call();
                call.Define();
            }
            else if (num == "2")
            {
                Call call = new Call();
                call.Display();
            }
            else { Console.WriteLine("Введите еще раз!"); Call(); }
        }
    }
    class Aspirant : Given
    {
        public string Record_book;
        public Aspirant(string surname, string name, int course, int book_num, string record_book)
            : base(surname, name, course, book_num)
        {
            Record_book = record_book;
        }
        public Aspirant() { }
        public override void Call()
        {
            Console.WriteLine($"\nAspirant {Name} {Surname} study in {Course} course by grade book number {Book_num},with record book {Record_book}");
            Console.Write("Если хотите продолжить нажмите 1,если нет нажмите 2 - ");
            string num = Console.ReadLine();
            if (num == "1")
            {
                Call call = new Call();
                call.Define();
            }
            else if (num == "2")
            {
                Call call = new Call();
                call.Display();
            }
            else { Console.WriteLine("Введите еще раз!"); Call(); }
        }
    }
    class Call
    {
        static int aspirant_quantity = 0;
        static int student_quantity = 0;
        static int Num1;
        static void TryParse(int x = 0)
        {
            int num1 = x;
            bool triger = false;
            while (triger == false)
            {
                if (int.TryParse(Console.ReadLine(), out num1))
                {
                    triger = true;
                }
                else
                {
                    Console.WriteLine("Введите число заново");
                    continue;
                }
            }
            Num1 = num1;
        }
        public void Display()
        {
            Console.WriteLine($"Количество аспирантов - {aspirant_quantity},количество - {student_quantity}");
        }
        public void Define(int x = 0)
        {
            Console.Write("\nЕсли хотите добавить студента нажмите - 1,аспиранта - 2 : ");
            TryParse();
            if (Num1 == 1)
            {
                Student student = new Student();
                bool check = true;
                while (check == true)
                {
                    Console.Write("Введите имя студента - ");
                    student.Name = Console.ReadLine();
                    Console.Write("Введите фамилию студента - ");
                    student.Surname = Console.ReadLine();
                    foreach (char a in student.Name + student.Surname)
                    {
                        if (a >= '0' && a <= '9')
                        {
                            Console.WriteLine("Попробуйте ввести  еще раз!\n");
                            check = true;
                            break;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                }
                Console.Write("Выберите курс обучения - ");
                TryParse();
                if (Num1 > 0 && Num1 < 5) { student.Course = Num1; }
                else { TryParse(); }
                Console.Write("Выберите номер зачетной книги - ");
                TryParse();
                if (Num1 > 0) { student.Book_num = Num1; }
                else { TryParse(); }
                student_quantity++;
                student.Call();
            }
            else if (Num1 == 2)
            {
                Aspirant aspirant = new Aspirant();
                bool check = true;
                while (check == true)
                {
                    Console.Write("Введите имя аспиранта - ");
                    aspirant.Name = Console.ReadLine();
                    Console.Write("Введите фамилию аспиранта - ");
                    aspirant.Surname = Console.ReadLine();
                    foreach (char a in aspirant.Name + aspirant.Surname)
                    {
                        if (a >= '0' && a <= '9')
                        {
                            Console.WriteLine("Попробуйте ввести  еще раз!\n");
                            check = true;
                            break;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                }
                Console.Write("Выберите курс обучения - ");
                TryParse();
                if (Num1 > 0 && Num1 < 5) { aspirant.Course = Num1; }
                else { Console.WriteLine("Попробуйте ввести  еще раз!"); TryParse(); }
                Console.Write("Выберите номер зачетной книги - ");
                TryParse();
                if (Num1 > 0) { aspirant.Book_num = Num1; }
                else { TryParse(); }
                Console.Write("Выберите номер  книги дисертации - ");
                aspirant.Record_book = Console.ReadLine();
                aspirant_quantity++;
                aspirant.Call();
            }
            else { Console.WriteLine("Попробуйте ввести  еще раз!\n"); Define(); }
        }
        static void Main()
        {
            Console.WriteLine($"Привет!");
            Call name = new Call();
            name.Define();
        }
    }
}
