using SalesApp.BL.Models;
using SalesApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesApp.Presenter.Services
{
   public class CsvFileReader:IDisposable
    {
        private static int _indexOrderDate = 0;
        private static int _indexCustomer = 1;
        private static int _indexProduct = 2;
        private static int _indexAmount = 3;
        private string _pathFile;
        public char Dilimiter { get; set; } = ';';
        private string[] _orderValues;
        public CsvFileReader(string pathFile)
        {
            _pathFile = pathFile;
        }

        public ManagerBL GetManager()
        {
            try
            {
                string fileName = GetFileName(_pathFile);
                string managerDataFromFileName = Path.GetFileNameWithoutExtension(fileName);
                Regex r = new Regex(@"\w+_\d{8}$");
                if (!r.IsMatch(managerDataFromFileName))
                {
                    throw new Exception("Invalid file name");
                }
                ManagerBL manager = new ManagerBL();
                manager.Name = GetManagerLastName(managerDataFromFileName);
                return manager;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void CreateObject(string sourceLine)
        {
            int countDilimiter = new Regex($@"{Dilimiter}").Matches(sourceLine).Count;
            if (countDilimiter > 3)
            {
                throw new FormatException("Uncorrect record");
            }
            _orderValues = sourceLine.Split(new char[] { Dilimiter }, StringSplitOptions.RemoveEmptyEntries);
        }
        public ReportBL GetReport(int managerId)
        {
            string fileName = Path.GetFileNameWithoutExtension(_pathFile);
            return new ReportBL() { ManagerId = managerId, ReportDate = GetReportDate(fileName) };
        }
        public OrderBL GetOrder(int customerId, int productId, int reportId)
        {
            decimal amount = ParceToDecimal(_orderValues[_indexAmount]);
            DateTime dateTime = ParceToDate(_orderValues[_indexOrderDate]);
            return new OrderBL() { OrderDate = dateTime, CustomerId = customerId, ProductId = productId, ReportId = reportId, Amount = amount };
        }
        public CustomerBL GetCustomer()
        {
            string firstName;
            string lastName;
            GetCustomerFirstLastNames(out firstName, out lastName, _orderValues[_indexCustomer]);
            return new CustomerBL() { FirstName = firstName, LastName = lastName };
        }
        public ProductBL GetProduct()
        {

            return new ProductBL() { Name = _orderValues[_indexProduct]?.Trim() };
        }

        private string GetFileName(string pathFile)
        {

            return Path.GetFileName(pathFile);
        }
        private void GetCustomerFirstLastNames(out string firstName, out string lastName, string source)
        {
            string[] names = source.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            firstName = names[0];
            lastName = names[1];
        }

        private DateTime ParceToDate(string source)
        {
            return DateTime.Parse(source);
        }
        private decimal ParceToDecimal(string source)
        {
            return decimal.Parse(source.Trim());
        }
        private string GetManagerLastName(string source)
        {
            return source.Split('_')[0];

        }
        private DateTime GetReportDate(string source)
        {
            string date = source.Split('_')[1].Insert(2, ".").Insert(5, ".");
            return Convert.ToDateTime(date);
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
