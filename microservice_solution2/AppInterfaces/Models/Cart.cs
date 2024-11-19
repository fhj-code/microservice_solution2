using System.Collections.Generic;

namespace microservice_solution2.Models
{
    public class Cart
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
