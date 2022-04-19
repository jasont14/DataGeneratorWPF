using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGeneratorWPF.Model;


namespace DataGeneratorWPF.Generator
{ 
    public class GeneratorOrderDetail
    {
        private  int _OrderDetailsToCreate;
        private List<Product> _products;
        private Random _random;

        public  GeneratorOrderDetail(GeneratorConfig config, List<Product> products)
        {
            _random = new Random();
            _OrderDetailsToCreate = _random.Next(1, 5);
            _products = products;
        }

        private OrderDetail GenerateOrderDetail(Guid orderId)
        {
            OrderDetail OrderDetail = new OrderDetail();

            OrderDetail.OrderDetailId = Guid.NewGuid();
            OrderDetail.OrderId = orderId;
            OrderDetail.Quanity = _random.Next(1,12);
            Guid prodId = _products[_random.Next(_products.Count)].ProductId;
            OrderDetail.ProductId = prodId;
            OrderDetail.Price = _products.Where(x => x.ProductId == prodId).Select(x => x.BasePrice).FirstOrDefault();

            return OrderDetail;
        }

        public  List<OrderDetail> GenerateOrderDetails(Guid orderId)
        {
            List<OrderDetail> OrderDetails = new List<OrderDetail>();

            for (int i = 0; i < _OrderDetailsToCreate; i++)
            {
                OrderDetails.Add(GenerateOrderDetail(orderId));
            }

            return OrderDetails;
        }

    }
}
