using MainData;
using System;


namespace AnimalManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal dog = new Animal();

            dog.InputInfo();
            dog.DisplayInfo();
            Console.ReadKey();

        }
    }
}

namespace MainData
{
    class Animal
    {
        private string name = "";
        private int age = 0;
        private float height = 0;
        private float weight = 0;
        public Animal() { }
        public Animal(string name, int age, float height, float weight)
        {
            this.name = name;
            this.age = age;
            this.height = height;
            this.weight = weight;
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Name: {0}, age: {1}, height: {2}, weight: {3}", name, age, height, weight);
        }
        public class NegativeNumException : Exception
        {
            public NegativeNumException() { }
            public NegativeNumException(string message) : base(message) { }
        }

        public void InputInfo()
        {
            // Input name;
            Console.Write("Input name of dog: ");
            name = Console.ReadLine();

            // Input Age
            InputAge();

            // Input Height
            Console.Write("Input height: ");
            string strHeight = Console.ReadLine();
            height = CheckFormat(strHeight);

            // Input Weight
            Console.Write("Input weight: ");
            string strWeight = Console.ReadLine();
            weight = CheckFormat(strWeight);
        }
        public void InputAge()
        {
            bool isCompleted = false;
            Console.Write("Input age of dog: ");
            string str = Console.ReadLine();
            do
            {
                try
                {
                    age = int.Parse(str);
                    if (age < 0)
                    {
                        throw new NegativeNumException();

                    }
                    else if (age > 20)
                    {
                        throw new Exception();
                    }

                    isCompleted = true;
                }
                catch (NegativeNumException)
                {
                    Console.Write("Negative age is not accepted, please input positive number: ");
                    str = Console.ReadLine();
                    age = int.Parse(str);
                }
                catch (Exception)
                {
                    Console.Write("Age greater than 20 is not accepted, please input smaller age: ");
                    str = Console.ReadLine();
                    age = int.Parse(str);
                }
            } while (!isCompleted);

        }

        public float CheckFormat(string str)
        {
            float measure = 0;
            bool isCompleted = false;
            do
            {
                try
                {
                    measure = float.Parse(str);
                    if (measure.GetType() != typeof(float))
                    {
                        throw new FormatException();
                    }
                    isCompleted = true;
                }
                catch (FormatException)
                {
                    Console.Write("Number required: ");
                    str = Console.ReadLine();
                    // measure = float.Parse(str);
                }
            } while (!isCompleted);
            return measure;

        }

    }
}
