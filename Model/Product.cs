using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGeneratorWPF.Model
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public double BasePrice   { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return (ProductId.ToString() + " | " + Name.ToString() +  " | " + Type.ToString());
        }

    }
}
