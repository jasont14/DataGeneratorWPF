using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGeneratorWPF.Model
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public override string ToString()
        {
            string delim = " | ";
            string returnString = OrderId.ToString() + delim + CustomerId.ToString() + delim + OrderDate.ToString();
            foreach (OrderDetail detail in OrderDetails)
            {
                returnString += (delim + detail.ToString());
            }
            
            return returnString;
        }
    }
}
