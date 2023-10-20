using MainData;
using System;

namespace StudentListManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            int nSV = 2;
            int nGV = 1;
            Student student;
            Lecturer lecturer;
            object[] obj = new object[nSV + nGV];
            for (int i = 0; i < nSV; i++)
            {
                student = new Student();
                student.InputInfo();
                obj[i] = (Student)student;
            }

            for (int i = 0; i < nGV; i++)
            {
                lecturer = new Lecturer();
                lecturer.InputInfo();
                obj[nSV + i] = (Lecturer)lecturer;
            }

            for (int i = 0; i < nSV + nGV; i++)
            {
                if (obj[i].GetType() == typeof(Student))
                {
                    Console.WriteLine("Information of students: ");
                    student = (Student)obj[i];
                    student.DisplayInfo();
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Information of lecturer: ");
                    lecturer = (Lecturer)obj[i];
                    lecturer.DisplayInfo();
                    Console.ReadKey();
                }
            }

        }
    }
}

namespace MainData
{
    public class NegativeNumException : Exception
    {
        public NegativeNumException() { }
        public NegativeNumException(string message) : base(message) { }

    };
    public class Student
    {
        private string name = "";
        private string code = "";
        private int age = 0;

        public Student() { }
        public Student(string name, string code, int age)
        {
            this.name = name;
            this.code = code;
            this.age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Code = {0}, Name = {1}, Age = {2}", this.code, this.name, this.age);
        }
        public override string ToString() => "Code = " + this.code + " name = " + this.name + " age = " + this.age;

        public void InputInfo()
        {

            Console.WriteLine("Input student name: ");
            name = Console.ReadLine();
            Console.WriteLine("Input student code: ");
            code = Console.ReadLine();
            Console.WriteLine("Input student age: ");
            string str = Console.ReadLine();
            try
            {
                age = int.Parse(str);
                if (age <= 0)
                {
                    throw new NegativeNumException();
                }
            }
            catch (FormatException)
            {
                Console.Write("The input is not number, please input a number: ");
                str = Console.ReadLine();
                age = int.Parse(str);
            }
            catch (NegativeNumException)
            {
                Console.Write("The input is a negative number, please input the positive number: ");
                str = Console.ReadLine();
                age = int.Parse(str);
            }

        }
    }

    public class Lecturer
    {
        private int age = 0;
        private string name = "";
        private string department = "";

        public Lecturer() { }
        public Lecturer(int age, string name, string department)
        {
            this.age = age;
            this.name = name;
            this.department = department;
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Department = {0}, Name = {1}, Age = {2}", this.department, this.name, this.age);
        }
        public override string ToString() => "Department = " + this.department + " name = " + this.name + " age = " + this.age;

        public void InputInfo()
        {
            Console.WriteLine("Input lecturer name: ");
            name = Console.ReadLine();
            Console.WriteLine("Input lecturer deparment: ");
            department = Console.ReadLine();
            Console.WriteLine("Input lecturer age: ");
            string str = Console.ReadLine();
            try
            {
                age = int.Parse(str);
                if (age <= 0)
                {
                    throw new NegativeNumException();
                }
            }
            catch (FormatException)
            {
                Console.Write("The input is not number, please input a number: ");
                str = Console.ReadLine();
                age = int.Parse(str);
            }
            catch (NegativeNumException)
            {
                Console.Write("The input is a negative number, please input the positive number: ");
                str = Console.ReadLine();
                age = int.Parse(str);
            }
        }
    }

}
