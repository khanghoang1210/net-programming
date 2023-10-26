using MainData;
using System;

namespace SportManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of sports you want to input information: ");
            int n = int.Parse(Console.ReadLine());
            object[] obj = new object[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1}. Enter sport information (f for football, t for tennis, v for volleyball): ");
                string typeSport = "";
                try
                {
                    typeSport = Console.ReadLine();

                    if (typeSport != "f" && typeSport != "t" && typeSport != "v")
                    {
                        throw new FormatException();
                    }

                }
                catch (FormatException)
                {
                    Console.Write("Please input one of three character (f/t/v): ");
                    typeSport = Console.ReadLine();
                }

                if (typeSport == "f")
                {
                    Football football = new Football();
                    football.Input();
                    obj[i] = (Football)football;
                }
                else if (typeSport == "t")
                {
                    Tennis tennis = new Tennis();
                    tennis.Input();
                    obj[i] = (Tennis)tennis;

                }
                else if (typeSport == "v")
                {
                    Volleyball volleyball = new Volleyball();
                    volleyball.Input();
                    obj[i] = (Volleyball)volleyball;

                }

            }
            for (int i = 0; i < n; i++)
            {
                if (obj[i].GetType() == typeof(Football))
                {
                    Football football = (Football)obj[i];
                    football.Display();
                }
                else if (obj[i].GetType() == typeof(Tennis))
                {
                    Tennis tennis = (Tennis)obj[i];
                    tennis.Display();
                }
                else
                {
                    Volleyball volleyball = (Volleyball)obj[i];
                    volleyball.Display();
                }
            }
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

        protected string ballType;

        public Sport() { }
        public Sport(int numOfPlayer, int time, string ballType) { }

        public virtual void Display()
        {
            Console.WriteLine($"Number of player: {numOfPlayer}");
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
                else if (numOfPlayer.GetType() != typeof(int))
                {
                    throw new FormatException();
                }

            }
            catch (NegativeNumberException)
            {
                Console.Write("Negative number is not accepted, please enter positive number: ");
                strNum = Console.ReadLine();
                numOfPlayer = int.Parse(strNum);
            }
            catch (FormatException)
            {
                Console.Write("Integer number is required: ");
                strNum = Console.ReadLine();
                numOfPlayer = int.Parse(strNum);
            }
            catch (Exception)
            {
                Console.Write("Some thing went wrong, please reinput: ");
                strNum = Console.ReadLine();
                numOfPlayer = int.Parse(strNum);
            }
            Console.Write("Enter type of ball: ");
            ballType = Console.ReadLine();


        }
    }

    public class Football : Sport
    {
        private const string name = "Football";
        private string playTime;
        private string footballType;
        public Football() { }
        public override void Display()
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Name of sport: {name}");
            base.Display();
            Console.WriteLine($"Time of match: {playTime}");
            Console.WriteLine($"Types of football: {footballType}");

        }

        public override void Input()
        {
            base.Input();
            Console.Write("Enter type of football (futsal/beach/association football): ");
            footballType = Console.ReadLine();
            Console.Write("Enter time of match (minute): ");
            playTime = Console.ReadLine();
        }
    }

    public class Tennis : Sport
    {
        private const string name = "Tennis";
        private string courtType;
        private int setNums;

        public Tennis() { }

        public override void Display()
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Name of sport: {name}");
            base.Display();
            Console.WriteLine($"Number of sets: {setNums}");
            Console.WriteLine($"Type of court: {courtType}"); // single or couple
        }
        public override void Input()
        {
            base.Input();
            Console.Write("Enter type of court (single/couple): ");
            courtType = Console.ReadLine();
            Console.Write("Enter number of sets: ");
            string str = Console.ReadLine();
            try
            {
                setNums = int.Parse(str);
                if (setNums <= 0)
                {
                    throw new NegativeNumberException();
                }
                else if (setNums.GetType() != typeof(int))
                {
                    throw new FormatException();
                }

            }
            catch (NegativeNumberException)
            {
                Console.Write("Negative number is not accepted, please enter positive number: ");
                str = Console.ReadLine();
                setNums = int.Parse(str);
            }
            catch (FormatException)
            {
                Console.Write("Integer number is required: ");
                str = Console.ReadLine();
                setNums = int.Parse(str);
            }
            catch (Exception)
            {
                Console.Write("Some thing went wrong, please reinput: ");
                str = Console.ReadLine();
                setNums = int.Parse(str);
            }

        }
    }

    public class Volleyball : Sport
    {
        private const string name = "Volleyball";
        private string volleyballType;
        private int setNums;
        private float netHeight;

        public Volleyball() { }
        public override void Display()

        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Name of sport: {name}");
            base.Display();
            Console.WriteLine($"Number of sets: {setNums} set(s)");
            Console.WriteLine($"Type of volleyball: {volleyballType}");
            Console.WriteLine($"Height of net: {netHeight} cm");
        }
        public override void Input()
        {
            base.Input();
            Console.Write("Enter types of volleyball (indoor/beach): ");
            volleyballType = Console.ReadLine();
            Console.Write("Enter height of net (cm): ");
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
                    throw new FormatException();
                }

            }
            catch (NegativeNumberException)
            {
                Console.Write("Negative number is not accepted, please enter positive number: ");
                str = Console.ReadLine();
                netHeight = float.Parse(str);
            }
            catch (FormatException)
            {
                Console.Write("Number required: ");
                str = Console.ReadLine();
                netHeight = float.Parse(str);
            }
            catch (Exception)
            {
                Console.Write("Some thing went wrong, please reinput: ");
                str = Console.ReadLine();
                netHeight = int.Parse(str);
            }

            Console.Write("Enter number of sets: ");
            string strNum = Console.ReadLine();
            try
            {
                setNums = int.Parse(strNum);
                if (setNums <= 0)
                {
                    throw new NegativeNumberException();
                }
                else if (setNums.GetType() != typeof(int))
                {
                    throw new FormatException();
                }

            }
            catch (NegativeNumberException)
            {
                Console.Write("Negative number is not accepted, please enter positive number: ");
                strNum = Console.ReadLine();
                setNums = int.Parse(strNum);
            }
            catch (FormatException)
            {
                Console.Write("Number required: ");
                strNum = Console.ReadLine();
                setNums = int.Parse(strNum);
            }
            catch (Exception)
            {
                Console.Write("Some thing went wrong, please reinput: ");
                str = Console.ReadLine();
                setNums = int.Parse(str);
            }

        }

    }
}
