using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGeneratorWPF.Model;

namespace DataGeneratorWPF.Generator
{
    public class GeneratorManager
    {
        public List<Customer> CustomerList { get; set; }
        public List<Order> OrderList { get; set; }
        public List<Product> ProductList{ get; set; }

        GeneratorProduct gp;
        GeneratorConfig _config;

        public GeneratorManager(GeneratorConfig config)
        {
            _config = config;
        }

        public bool Initialize(bool AllOrders)
        {
            GeneratorProduct gp = new GeneratorProduct(_config);
            ProductList = gp.GenerateProducts();

            GeneratorCustomer gc = new GeneratorCustomer(_config);
            CustomerList = gc.GenerateCustomers();

            if (AllOrders){

                GeneratorOrder goo = new GeneratorOrder(_config, CustomerList, ProductList);
                OrderList = goo.GenerateOrders();
            }


            return true;
        }


        public bool GenerateAll() //Generates All per config file
        {
            if (Initialize(true))
            {
                return true;
            }
            
            return false;            
        }

        public bool GenerateAllSpecificYear(int specificYear)
        {
            _config.StartYear = specificYear;

            if (Initialize(true))
            {
                return true;
            }

            return false;
        }

        public bool GenerateAllCurrentYear()
        {
            _config.StartYear = DateTime.Now.Year;

            if (Initialize(false))
            {
                GeneratorOrder goo = new GeneratorOrder(_config, CustomerList, ProductList);
                OrderList = goo.GenerateOrdersToCurrentYear();
                return true;
            }

            return false;
        }



        public Order GenerateSingleOrder(DateTime dateTime)
        {
            Order order = new Order();  
            if (Initialize(false))
            {
                GeneratorOrder goo = new GeneratorOrder(_config, CustomerList, ProductList) ;
                order = goo.GenerateOrder(dateTime);
                
            }

            

            return order;
        }

        public Order GenerateSingleOrder(DateTime dateTime, List<Customer> customers, List<Product> products)
        {
            Order order = new Order();
            if (Initialize(false))
            {
                GeneratorOrder goo = new GeneratorOrder(_config, customers, products);
                order = goo.GenerateOrder(dateTime);

            }



            return order;
        }
    }
}
