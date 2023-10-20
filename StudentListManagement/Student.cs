using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace StudentListManagement
{
    namespace MainData
    {
        internal class Student
        {
            private string name = "";
            private string code = "";
            private int age = 10;
            public string Name { get { return name; } set { name = value; } }
            public int Age { get { return age; } set { age = value; } }

            public Student() { }

            public Student(string name = "", string code = "", int age = 0)
            {
                this.name = name;
                this.age = age;
            }

            public void display()
            {
                Console.WriteLine("I am {0} and i {1} years old", this.name, this.age);
            }
        }
    }

}
