using AttributeData;
using MainData;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MilkManagement
{
    internal class Program
    {
        [DllImport("User32.dll")]
        public static extern int MessageBox(int hParent, string Message, string Caption, int Type);
        static void Main(string[] args)
        {
            Milk milk = new Milk();
            milk.ValMilkName = "Vinamilk";
            milk.ValQuantity = 1;
            milk.ValProductionDate = "28/10/2023";
            milk.ValExpiredDate = "28/11/2023";

            Type type = typeof(Milk);
            string OutPutInfo = "Class modify information: ";
            foreach (Object attributes in type.GetCustomAttributes(false))
            {
                MilkMoreInfo milkMore = (MilkMoreInfo)attributes;
                if (milk != null)
                {
                    OutPutInfo = String.Format($"\n Manufacturer: {milkMore.Manufacturer} \n Company name: {milkMore.CompanyName}");
                    Console.WriteLine(OutPutInfo);
                }
            }

            string OutPutMessage = String.Format($"\n Milk ID: {milk.ValMilkID} \n Name: {milk.ValMilkName}");
            OutPutMessage += String.Format($"\n Production date: {milk.ValProductionDate} \n Expired Date: {milk.ValExpiredDate}");
            OutPutMessage += String.Format($"\n Quantity: {milk.ValQuantity}");


            //Console.WriteLine("Milk information: ");
            //Console.WriteLine($"Milk Id: {milk.ValMilkID}");
            //Console.WriteLine($"Milk name: {milk.ValMilkName}");
            //Console.WriteLine($"Production date: {milk.ValProductionDate}");
            //Console.WriteLine($"Expired date: {milk.ValExpiredDate}");
            //Console.WriteLine($"Quantity: {milk.ValQuantity}");
            MessageBox(0, OutPutMessage, "Milk Information", 1);
            Console.ReadKey();
        }
    }
}

namespace MainData
{
    [MilkMoreInfo("Vinamilk", "Coop Food")]
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
                MilkID = String.Format($"MILK{ProductionDate:ddMMyyyy}");
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
namespace AttributeData
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class MilkMoreInfo : System.Attribute
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