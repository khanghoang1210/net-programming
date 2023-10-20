using MainData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport
{
    class Program
    {
        static void Main(string[] args)
        {
            Football football = new Football();
            football.Input();
            football.Display();
            Console.ReadKey();

        }
    }
}
namespace MainData
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException() { }
        public NegativeNumberException(string message) : base(message) { }
    }
    public class Sport
    {
        protected int numOfPlayer;
        protected string playTime;
        protected string ballType;

        public Sport() { }
        public Sport(int numOfPlayer, int time, string ballType) { }

        public virtual void Display()
        {
            Console.WriteLine($"Number of player: {numOfPlayer}");
            Console.WriteLine($"Time of a match: {playTime}");
            Console.WriteLine($"Type of ball: {ballType}");
        }

        public virtual void Input()
        {
            Console.Write("Enter number of player: ");
            string strNum = Console.ReadLine();
            try
            {
                numOfPlayer = int.Parse(strNum);
                if (numOfPlayer <= 0)
                {
                    throw new NegativeNumberException();
                }

            }
            catch (NegativeNumberException)
            {
                Console.Write("Negative number is not accepted, please enter positive number: ");
            }
            Console.Write("Enter time of match: ");
            playTime = Console.ReadLine();
            Console.Write("Enter type of ball: ");
            ballType = Console.ReadLine();


        }
    }

    public class Football : Sport
    {
        private string name = "Football";
        private int fieldType;
        public Football() { }
        public override void Display()
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Name of sport: {name}");
            base.Display();
            Console.WriteLine($"Type of field: {fieldType}");

        }

        public override void Input()
        {
            base.Input();
            Console.Write("Enter type of field: ");
            string str = Console.ReadLine();
            try
            {
                fieldType = int.Parse(str);
                if (fieldType <= 0)
                {
                    throw new NegativeNumberException();
                }
                else if (fieldType.GetType() != typeof(int))
                {
                    throw new Exception();
                }

            }
            catch (NegativeNumberException)
            {
                Console.Write("Negative number is not accepted, please enter positive number: ");
                str = Console.ReadLine();
                fieldType = int.Parse(str);
            }
            catch (Exception)
            {
                Console.Write("Number required: ");
                str = Console.ReadLine();
                fieldType = int.Parse(str);
            }
        }
    }

    public class Tennis : Sport
    {
        private string name = "Tennis";
        private string courtType;

        public Tennis() { }

        public override void Display()
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Name of sport: {name}");
            base.Display();
            Console.WriteLine($"Type of court: {courtType}"); // single or couple
        }
        public override void Input()
        {
            base.Input();
            Console.Write("Enter type of field: ");
            courtType = Console.ReadLine();
        }
    }

    public class Volleyball : Sport
    {
        private string name = "Volleyball";
        private float netHeight;

        public Volleyball() { }
        public override void Display()

        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Name of sport: {name}");
            base.Display();
            Console.WriteLine($"Height of net: {netHeight}");
        }
        public override void Input()
        {
            base.Input();
            Console.Write("Enter type of field: ");
            string str = Console.ReadLine();
            try
            {
                netHeight = float.Parse(str);
                if (netHeight <= 0)
                {
                    throw new NegativeNumberException();
                }
                else if (netHeight.GetType() != typeof(float))
                {
                    throw new Exception();
                }

            }
            catch (NegativeNumberException)
            {
                Console.Write("Negative number is not accepted, please enter positive number: ");
                str = Console.ReadLine();
                netHeight = float.Parse(str);
            }
            catch (Exception e)
            {
                Console.WriteLine("Number require: ");
                str = Console.ReadLine();
                netHeight = float.Parse(str);
            }
        }

    }
}
