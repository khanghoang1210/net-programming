using AttributeData;
using MainData;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

delegate void MilkInOut();
namespace MilkManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Milk milk = new Milk();
            MilkInOut milkInput = new MilkInOut(milk.Input);
            MilkInOut milkDisplay = new MilkInOut(milk.Display);
            milkInput();

            //milk.Input();

            Type type = typeof(Milk);
            string OutPutInfo = "Class modify information: ";
            foreach (Object attributes in type.GetCustomAttributes(false))
            {
                MilkMoreInfo milkMore = (MilkMoreInfo)attributes;
                if (milk != null)
                {
                    OutPutInfo = String.Format($"\nManufacturer: {milkMore.Manufacturer} \nCompany name: {milkMore.CompanyName}");
                    Console.WriteLine(OutPutInfo);
                }
            }
            milkDisplay();
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
    interface IMilkActions
    {
        void Input();
        void Display();
    }
    [MilkMoreInfo("Vinamilk", "Coop Food")]
    public class Milk : IMilkActions
    {
        [DllImport("User32.dll")]
        public static extern int MessageBox(int hParent, string Message, string Caption, int Type);

        private string MilkName;
        private string MilkID;
        private DateTime ProductionDate;
        private DateTime ExpiredDate;
        private int Quantity;


        public Milk(string MilkName = "Not Asigned", string ProductionDate = "01/01/2023",
           string ExpiredDate = "01/02/2023", int Quantity = 0)
        {
            this.MilkName = MilkName;
            this.ProductionDate = DateTime.ParseExact(ProductionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.ExpiredDate = DateTime.ParseExact(ExpiredDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.Quantity = Quantity;
            MilkID = String.Format($"MILK{this.ProductionDate.ToString("ddMMyyy")}");
        }
        public Milk() { }

        public string ValMilkName { get { return MilkName; } set { MilkName = value; } }
        public string ValMilkID { get { return MilkID; } }
        public string ValProductionDate
        {
            get { return ProductionDate.ToString(); }
            set
            {
                ProductionDate = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                MilkID = String.Format($"MILK{this.ProductionDate.ToString("ddMMyyyy")}");
            }
        }
        public string ValExpiredDate
        {
            get { return ExpiredDate.ToString(); }
            set
            {
                ExpiredDate = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }
        public int ValQuantity { get { return Quantity; } set { Quantity = value; } }

        public void Input()
        {
            Console.Write("Enter milk name: ");
            MilkName = Console.ReadLine();
            Console.Write("Enter production date: ");
            string strProDate = Console.ReadLine();
            try
            {
                //ProductionDate = DateTime.ParseExact(strProDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ValProductionDate = strProDate;
                if (ProductionDate.GetType() != typeof(DateTime))
                {
                    throw new FormatException();
                }

            }
            catch (FormatException)
            {
                Console.Write("Please reinput with dd/mm/yyyy format: ");
                strProDate = Console.ReadLine();
                //ProductionDate = DateTime.ParseExact(strProDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ValProductionDate = strProDate;
            }
            Console.Write("Enter expired date: ");
            string strExpDate = Console.ReadLine();
            try
            {
                ExpiredDate = DateTime.ParseExact(strExpDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (ExpiredDate.GetType() != typeof(DateTime))
                {
                    throw new FormatException();
                }
                if (ExpiredDate < ProductionDate)
                {
                    throw new Exception();
                }

            }
            catch (FormatException)
            {
                Console.Write("Please reinput with dd/mm/yyyy format: ");
                strExpDate = Console.ReadLine();
                ExpiredDate = DateTime.ParseExact(strExpDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                Console.Write("Expired date must be greater than to the production date: ");
                strExpDate = Console.ReadLine();
                ExpiredDate = DateTime.ParseExact(strExpDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            Console.Write("Enter quantity: ");
            string str = Console.ReadLine();
            try
            {
                Quantity = int.Parse(str);
                if (Quantity < 0)
                {
                    throw new NegativeNumberException();
                }
                else if (Quantity.GetType() != typeof(int))
                {
                    throw new FormatException();
                }

            }
            catch (NegativeNumberException)
            {
                Console.Write("Positive number is required: ");
                str = Console.ReadLine();
                Quantity = int.Parse(str);
            }
            catch (FormatException)
            {
                Console.Write("Integer number is required: ");
                str = Console.ReadLine();
                Quantity = int.Parse(str);
            }
            catch (Exception)
            {
                Console.Write("Oops, some thing went wrong!");
                str = Console.ReadLine();
                Quantity = int.Parse(str);
            }
        }
        public void Display()
        {
            string OutPutMessage = String.Format($"\n Milk ID: {ValMilkID} \n Name: {ValMilkName}");
            OutPutMessage += String.Format($"\n Production date: {ValProductionDate} \n Expired Date: {ValExpiredDate}");
            OutPutMessage += String.Format($"\n Quantity: {ValQuantity}");
            MessageBox(0, OutPutMessage, "Milk Information", 1);
        }

    }
}
namespace AttributeData
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class MilkMoreInfo : Attribute
    {
        public string Manufacturer { get; set; }
        public string CompanyName { get; set; }

        public MilkMoreInfo(string Manufactuer = "", string companyName = "")
        {

            this.Manufacturer = Manufactuer;
            this.CompanyName = companyName;
        }
    }
}