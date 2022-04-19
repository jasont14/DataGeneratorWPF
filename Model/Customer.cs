using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

namespace DataGeneratorWPF.Model
{
    public class Customer
    {   
        [Key]
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            string delim = " | ";
            return CustomerId.ToString() + delim + FirstName + delim + LastName + delim + Address + delim + City + State + delim + Zip + Email;
        }
    }
}
