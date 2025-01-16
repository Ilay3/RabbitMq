using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Domain.Entities
{
    public class OrderItem
    {
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(string productName, int quantity)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name cannot be empty.");
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            ProductName = productName;
            Quantity = quantity;
        }
    }

}
