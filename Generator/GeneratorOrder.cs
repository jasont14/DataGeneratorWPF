using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGeneratorWPF.Generator;
using DataGeneratorWPF.Model;

namespace DataGeneratorWPF.Generator
{
    public class GeneratorOrder
    {
        
        Order order = new Order();
        private Random _random;
        GeneratorConfig _config;        
        List<Customer> _customerList;
        List<Product> _productList;

        public GeneratorOrder(GeneratorConfig config, List<Customer> customerList, List<Product> productList)
        {
            _config = config;
            _customerList = customerList;
            _productList = productList;
            _random = new Random();            
        }

        public Order GenerateOrder(DateTime _date) //Return order for specific date
        {
            GeneratorOrderDetail good = new GeneratorOrderDetail(_config, _productList);
            Guid guid = Guid.NewGuid();

            Order order = new Order();
            order.OrderId = guid;
            order.OrderDate = _date;
            order.CustomerId = _customerList[_random.Next(_customerList.Count)].CustomerId;
            order.OrderDetails = good.GenerateOrderDetails(guid);

            return order;           
        }

        //Returns orders for specific month and year
        //Orders count is random and set in GeneratorConfig
        public List<Order> GenerateOrdersForMonthYear(int orderMonth, int orderYear) 
        {
            int currMonth = orderMonth;
            int orderDaysInMonth = _random.Next(29);
            int currYear = orderYear;
            List<Order> orders = new List<Order>();

            for (int i = 0; i < currMonth; i++)
            {
                for (int j = 0; j < orderDaysInMonth; j++)
                {
                    for (int k = 0; k < _random.Next(1, _config.OrdersToCreatePerDay); k++)
                    {
                        DateTime orderDate = new DateTime(orderYear, i + 1, _random.Next(1, 28));
                        orders.Add(GenerateOrder(orderDate));
                    }
                }
            }
            return orders;
        }

        //Generates orders for current month
        public List<Order> GenerateOrdersForCurrentMonth() //Returns orders for current month
        {
            int currMonth = GetCurrentMonth();
            int orderDaysInMonth = _random.Next(29);
            int currYear = _config.StartYear;
            List<Order> orders = GenerateOrdersForMonthYear(currMonth, currYear);   

            return orders;
        }

        public List<Order> GenerateOrders() //Returns orders based upon config parms. Start year and number of years.
        {
            List<Order> orders = new List<Order> ();
            int yearStart = _config.StartYear;
            int monthsInYear = 12;
            int orderDaysInMonth = _random.Next(29);

            for (int i = 0; i < _config.YearsToCreate; i++) //year
            {
                yearStart = yearStart + i;

                for (int j = 1; j <= monthsInYear; j++)  //months
                {
                    orders.AddRange(GenerateOrdersForMonthYear(j, yearStart));  //j = months, i = year
                }
            }

            return orders;
        }

        public List<Order> GenerateOrdersToCurrentYear()
        {
            List<Order> orders = new List<Order>();
            int yearStart = _config.StartYear;
            int monthsInYear = GetCurrentMonth();
            int orderDaysInMonth = _random.Next(29);
            int currentMonth = GetCurrentMonth();
            int currentYear = GetCurrentYear();

            for (int i = 1; i <= _config.YearsToCreate; i++)
            {
                if (i != 1)
                {
                    yearStart++;
                }
                if (yearStart == currentYear)
                {
                    monthsInYear = currentMonth;
                }
                for (int j = 0; j < monthsInYear; j++)
                {
                    orders.AddRange (GenerateOrdersForMonthYear(j, yearStart));
                }
            }

            return orders;
        }

        private int GetCurrentMonth()
        {
            DateTime dt = DateTime.Now;            
            return dt.Month;
        }

        private int GetCurrentYear()
        {
            DateTime dt = DateTime.Now;
            return dt.Year;
        }
    }
}
