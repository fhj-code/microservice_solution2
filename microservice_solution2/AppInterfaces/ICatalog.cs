using microservice_solution2.Models;
using Shed.CoreKit.WebApi;
using System;
using System.Collections.Generic;

namespace microservice_solution2
{
    public interface ICatalog
    {
        IEnumerable<Product> Get();

        [Route("get/{productId}")]
        public Product Get(Guid productId);
    }
}
