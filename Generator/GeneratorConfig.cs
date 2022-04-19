using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGeneratorWPF.Model;

namespace DataGeneratorWPF.Generator 
{ 
    public class GeneratorConfig
    {
        public int YearsToCreate { get; set; } = 1;
        public int StartYear { get; set; } = DateTime.Now.Year;
        public int CustomersToCreate { get; set; } = 10;
        public int ProductsToCreate { get; set; } = 10;
        public int OrdersToCreatePerDay { get; set; } = 100;

    }
}
