using MainData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Milk milk = new Milk();
            milk.ValMilkName = "Vinamilk";
            milk.ValQuantity = 1;
            milk.ValProductionDate = "28/10/2023";
            milk.ValExpiredDate = "28/11/2023";

            Console.WriteLine("Milk information: ");
            Console.WriteLine($"Milk Id: {milk.ValMilkID}");
            Console.WriteLine($"Milk name: {milk.ValMilkName}");
            Console.WriteLine($"Production date: {milk.ValProductionDate}");
            Console.WriteLine($"Expired date: {milk.ValExpiredDate}");
            Console.WriteLine($"Quantity: {milk.ValQuantity}");
            Console.ReadKey();
        }
    }
}

namespace MainData
{
    public class Milk
    {
        private string MilkName = "MILK01012023";
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
            this.MilkID = String.Format($"BOOK{this.ProductionDate.ToString("ddMMyyy")}");
        }
        //public Milk() { }
        public string ValMilkName { get { return MilkName; } set { MilkName = value; } }
        public string ValMilkID { get { return MilkID; } }
        public string ValProductionDate
        {
            get { return ProductionDate.ToString(); }
            set
            {
                ProductionDate = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                MilkID = String.Format($"MILK{ProductionDate.ToString("ddMMyyyy")}");
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

    }
}
