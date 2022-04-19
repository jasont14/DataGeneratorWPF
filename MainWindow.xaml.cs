using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using DataGeneratorWPF.Database;
using DataGeneratorWPF.Generator;
using DataGeneratorWPF.Model;

namespace DataGeneratorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GeneratorConfig config;
        GeneratorManager gm;

        public MainWindow()
        {
            InitializeComponent();
            config = new GeneratorConfig();
            gm = new GeneratorManager(config);
        }

        private void btnGenerateLiveData_Click(object sender, RoutedEventArgs e)
        {
            int timeOut = 30; //Seconds to timeout
            int retryWait = 10; //seconds to wait


            //Validate Product is there. If not add Product
            if (!ValidateProducts())
            {
                gm.Initialize(false);
                txtOutput.AppendText("No Products, Adding\r\n");
                bool padd = AddProducts();
            }           
            

            //Validate Customer is there. If not add Customer
            if (!ValidateCustomers())
            {
                txtOutput.AppendText("No Customers, Adding\r\n");
                bool cadd = AddCustomers();
            }

            using var context = new ApplicationContext();

            var customers = context.Customers.ToList();
            gm.CustomerList = customers;

            var products = context.Products.ToList();
            gm.ProductList = products;

            Order order = gm.GenerateSingleOrder(DateTime.Now, customers, products);
            context.Orders.Add(order);
            context.SaveChanges();
            txtOutput.AppendText(String.Format("Order Id {0} Generated \r\n", order.OrderId.ToString()));
        }

        private bool AddProducts()
        {
            using (var context = new ApplicationContext())
            {
                List<Product> products = gm.ProductList;
                context.Products.AddRange(products);
                context.SaveChanges();
            }
            txtOutput.AppendText("Products Added\r\n");
            return true;
        }

        private bool AddCustomers()
        {
            using (var context = new ApplicationContext())
            {
                List<Customer> customers = gm.CustomerList;
                context.Customers.AddRange(customers);  
                context.SaveChanges();
            }

            txtOutput.AppendText("Customers Added\r\n");
            return true;

        }

        private bool ValidateCustomers()
        {
            bool result = false;
            int count;

            using (var context = new ApplicationContext())
            {
                count = context.Customers.Count();    
            }

            if (count > 0)
            {
                return true;
            }

                return result;
        }

        private bool ValidateProducts()
        {
            bool result = false;

            int count;

            using (var context = new ApplicationContext())
            {
                count = context.Products.Count();
            }

            if (count > 0)
            {
                result = true;
            }

            return result;
        }
    }
}
