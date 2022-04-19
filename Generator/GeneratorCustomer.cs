using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGeneratorWPF.Model;

namespace DataGeneratorWPF.Generator
{
    public  class GeneratorCustomer
    {
        private  int _customersToCreate;

        public  GeneratorCustomer(GeneratorConfig config)
        {            
            _customersToCreate   = config.CustomersToCreate;            
        }

        private static Customer GenerateCustomer()
        {
            Customer customer = new Customer();

            customer.CustomerId = Guid.NewGuid();
            customer.FirstName = Faker.Name.First();
            customer.LastName = Faker.Name.Last();
            customer.Address = Faker.Address.StreetAddress();
            customer.City = Faker.Address.City();
            customer.State = Faker.Address.UsState();
            customer.Zip = Faker.Address.ZipCode();
            customer.Email = Faker.Internet.Email();
            customer.Phone = Faker.Phone.Number();

            return customer;
        }

        public  List<Customer> GenerateCustomers()
        {
            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < _customersToCreate; i++)
            {
                customers.Add(GenerateCustomer());
            }

            return customers;

        }
    }
}
