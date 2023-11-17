﻿using MainData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyManagement
{
    internal class Program
    {
        static void UpdateNumOfCustomer(Company company)
        {
            company.ValNumOfCustomer = company.CustomerList.Count;
        }
        static void Main(string[] args)
        {
            Company company = new Company();
            company.ValCompanyName = "CC";
            company.CustomerList.Add(new Customer("C002", "Khang", CustomerType.TrungThanh));
            company.CustomerList.Add(new Customer("C003", "Nhu", CustomerType.CanQuanTam));
            company.CustomerList.Add(new Customer("C004", "aa", CustomerType.CanQuanTam));
            company.CompanyAddOrRemoveEvent += new Company.CompanyHandler(UpdateNumOfCustomer);
            Customer customer = company.SearchCustomer("aa");
            company.RemoveCustomer(customer);
            company.CompanyInfo();

            Console.WriteLine("Search Process:");
            Console.WriteLine(company.SearchCustomer(1).ConvertToString());
            Console.WriteLine(company.SearchCustomer("Khang").ConvertToString());
            Console.ReadKey();
        }
    }
}
namespace MainData
{
    public static class MyExtension
    {
        public static string ConvertToString(this Customer customer)
        {
            string CustomerType = Enum.GetName(typeof(CustomerType), customer.ValCustomerType);
            if (customer.ValCustomerID != "C001")
            {
                return $"Khach hang {customer.ValCustomerID} - {customer.ValCustomerName} la khach hang {customer.ValCustomerType}";
            }
            return null;
        }
    }
    public enum CustomerType { TrungThanh, TiemNang, CanQuanTam, KhachHangKhac };
    public class Customer
    {
        string CustomerID = "C001";
        string CustomerName = "Not Assigned";
        CustomerType CustomerType = CustomerType.TrungThanh;
        public Customer() { }
        public Customer(string customerID, string customerName, CustomerType CustomerType)
        {
            this.CustomerID = customerID;
            this.CustomerName = customerName;
            this.CustomerType = CustomerType;
        }
        public string ValCustomerID
        {
            set { CustomerID = value; }
            get { return CustomerID; }
        }
        public string ValCustomerName
        {
            set { CustomerName = value; }
            get { return CustomerName; }
        }
        public CustomerType ValCustomerType
        {
            set { CustomerType = value; }
            get { return CustomerType; }
        }
        public void CustomerInfo()
        {
            string customerType = Enum.GetName(typeof(CustomerType), CustomerType);
            if (CustomerID != "C001")
            {
                Console.WriteLine($"Khach hang {CustomerID} - {CustomerName} la khach hang {CustomerType}");
            }
        }
    }

    public class Company
    {
        public delegate void CompanyHandler(Company company);
        public event CompanyHandler CompanyAddOrRemoveEvent;
        string CompanyName;
        public List<Customer> CustomerList;
        Dictionary<CustomerType, string> customerTypeInfo = new Dictionary<CustomerType, string>();
        int NumOfCustomer = 0;
        public Company()
        {
            CustomerList = new List<Customer>();
            CompanyName = "Not assigned";
            customerTypeInfo.Add(CustomerType.TrungThanh, "Khach hang gan bo voi cong ty tu 1 nam");
            customerTypeInfo.Add(CustomerType.TiemNang, "Khach hang thoi gian gan day mua hang so luong nhieu");
            customerTypeInfo.Add(CustomerType.CanQuanTam, "Khach hang con ban khoan ve gia ca");
            customerTypeInfo.Add(CustomerType.KhachHangKhac, "Khach hang chua ro thong tin");

        }
        public string ValCompanyName
        {
            set { CompanyName = value; }
            get { return CompanyName; }
        }
        public int ValNumOfCustomer
        {
            set { NumOfCustomer = value; }
            get { return NumOfCustomer; }
        }
        public void CompanyInfo()
        {
            Console.WriteLine($"Cong ty {CompanyName} co {CustomerList.Count} khach hang: ");
            foreach (Customer customer in CustomerList)
            {
                KeyValuePair<CustomerType, string> info = customerTypeInfo.FirstOrDefault(o => o.Key == customer.ValCustomerType);
                customer.CustomerInfo();
                Console.WriteLine($"---Thong tin khach hang: {info.Value}\n");
            }
        }
        public Customer SearchCustomer<T>(T search)
        {
            Customer customer = new Customer();
            if (typeof(T) == typeof(string))
            {
                customer = CustomerList.FirstOrDefault(o => o.ValCustomerName == search.ToString());
                if (customer != null)
                {
                    return customer;
                }
            }
            else if (typeof(T) == typeof(int))
            {
                if (Convert.ToInt32(search) < CustomerList.Count)
                {
                    return CustomerList[Convert.ToInt32(search)];
                }
            }
            return null;
        }
        public void AddCustomer(Customer customer)
        {
            CustomerList.Add(customer);
            OnCustomerChanger(this);
        }
        public void RemoveCustomer(Customer customer)
        {
            CustomerList.Remove(customer);
            OnCustomerChanger(this);
        }
        public void OnCustomerChanger(Company company)
        {
            if (CompanyAddOrRemoveEvent != null)
            {
                CompanyAddOrRemoveEvent(this);
            }
        }
    }
}