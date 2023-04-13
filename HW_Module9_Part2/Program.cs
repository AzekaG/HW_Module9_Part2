using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;


namespace tets
{


    public delegate T AddDelegate<T>(T x, T y);
    public class ExampleClass
    {
        public int AddInt(int x, int y)
        { return x + y; }
        public double AddDouble(double x, double y)
        { return x + y; }
        public char AddChar(char x, char y)
        { return (char)(x + y); }
        ///+++++++++++++++++++++++++++++++++++++++++++++++++++
        /// ++++++++++++++++++++++++++++++++++++++++++++++++++



        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
            public override string ToString()
            {
                return $"Surname : {LastName} , Name : {FirstName}, Born: {BirthDate.ToLongDateString()}";
            }
        }



        internal class Program
        {
            static string FullName(Student student)
            {
                return $"{student.LastName} \t{student.FirstName}";
            }
            static bool OnlySpring(Student student)
            {

                return student.BirthDate.Month > 2 && student.BirthDate.Month < 6;
            }
            static int SortBirthDate(Student student1, Student student2)
            {
                return student1.BirthDate.CompareTo(student2.BirthDate);

            }

            static void Main(string[] args)
            {
                #region "Example delegate
                {
                    //ExampleClass exampleClass = new ExampleClass();
                    //AddDelegate<int> delInt = exampleClass.AddInt;
                    //WriteLine($"The sum of integers : {delInt(8, 6)}");
                    //AddDelegate<double> delDouble = exampleClass.AddDouble;
                    //WriteLine($"the sum of doubles : {delDouble(5.4, 5.7)}");
                    //AddDelegate<char> delChar = exampleClass.AddChar;
                    //WriteLine($"The sum of chars : {delChar('S', 'h')}");
                }
                #endregion
                #region "Student"
                List<Student> list = new List<Student> {
                new Student{
                FirstName = "John",
                LastName = "Miller",
                BirthDate = new DateTime(2000,4,5) },
                 new Student{
                FirstName = "Anna",
                LastName = "Shlepa",
                BirthDate = new DateTime(2010,12,3) },
                  new Student{
                FirstName = "San9",
                LastName = "Kooper",
                BirthDate = new DateTime(1994,5,15) },
                   new Student{
                FirstName = "Vas9",
                LastName = "Igorevi4",
                BirthDate = new DateTime(2100,3,13) }

                };

                #endregion

                WriteLine("Sort Birth Date");
                List<Student> students = list;

                foreach (Student item in students)
                    WriteLine(item);

                list.Sort(SortBirthDate);
                foreach (Student item in students)
                    WriteLine(item);
            }
        }
    }
}