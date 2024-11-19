using System;

namespace microservice_solution2.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public Order Clone()
        {
            return new Order
            {
                Id = Id,
                Product = Product.Clone(),
                Quantity = Quantity

            };
        }
    }
}
