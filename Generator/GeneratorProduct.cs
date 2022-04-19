using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGeneratorWPF.Model;

namespace DataGeneratorWPF.Generator
{
    public class GeneratorProduct
    {
        private int _productsToCreate;

        public GeneratorProduct(GeneratorConfig config)
        {            
            _productsToCreate   = config.ProductsToCreate;            
        }       

        public Product GenerateProduct(string productName)
        {
            Random random = new Random();
            Product product = new Product();
            product.ProductId = Guid.NewGuid();
            product.Name = productName.Trim();
            product.BasePrice = random.NextDouble();
            product.Type = "null";

            return product;
        }
        public List<Product> GenerateProducts()
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < _productsToCreate; i++)
            {
                products.Add(GenerateProduct(ArrayOfProducts[i]));
            }

            return products;

        }



        private string[] ArrayOfProducts = {

                "Pens                               "
                ,"Pencils                            "
                ,"Markers                            "
                ,"Highlighters                       "
                ,"Paper clips                        "
                ,"Tape                               "
                ,"Rubber bands                       "
                ,"Erasers                            "
                ,"Stamp pads                         "
                ,"Ink for stamp pads                 "
                ,"Spiral notebooks                   "
                ,"Writing pads                       "
                ,"Post–it® notes                     "
                ,"Phone message pads                 "
                ,"Laser printer paper                "
                ,"Copy paper                         "
                ,"Fax paper                          "
                ,"Graph paper                        "
                ,"Colored paper                      "
                ,"Pocket notebook                    "
                ,"Manila file folders                "
                ,"Hanging file folders               "
                ,"Pocket folders                     "
                ,"File labels                        "
                ,"Index dividers                     "
                ,"Tabs                               "
                ,"Letter envelopes                   "
                ,"Catalog envelopes                  "
                ,"Padded envelopes                   "
                ,"Shipping paper                     "
                ,"Shipping labels                    "
                ,"Disk mailers                       "
                ,"Bubble wrap                        "
                ,"Sealing tape                       "
                ,"Toner cartridges                   "
                ,"3.5 Inch high density disks        "
                ,"CD–Roms                            "
                ,"Zip drive tapes                    "
                ,"Staples                            "
                ,"Bulldog clamps                     "
                ,"Fasteners                          "
                ,"Glue                               "
                ,"Glue sticks                        "
                ,"Reinforcements                     "
                ,"3–ring binders                     "
                ,"Pushpins                           "
                ,"Thumbtacks                         "
                ,"Map pins                           "
                ,"Price tags                         "
                ,"Name badges                        "
                ,"Labels                             "
                ,"Color coding labels                "
        };
    }
}
