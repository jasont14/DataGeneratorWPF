using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGeneratorWPF.Model
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get ; set; }
        public int Quanity { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            string delim = " | ";

            return "\r\nDETAILS:\r\n" + OrderDetailId.ToString() + delim + ProductId.ToString() + delim + OrderId.ToString() + delim + Quanity.ToString() + delim + Price.ToString() ;
        }
    }

}
