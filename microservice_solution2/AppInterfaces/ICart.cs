using microservice_solution2.Models;
using Shed.CoreKit.WebApi;
using System;
using System.Collections.Generic;

namespace microservice_solution2
{
    public interface ICart
    {
        Cart Get();

        [HttpPut, Route("addorder/{productId}/{qty}")]
        Cart AddOrder(Guid productId, int qty);

        Cart DeleteOrder(Guid orderId);

        [Route("getevents/{timestamp}")]
        IEnumerable<CartEvent> GetCartEvents(long timestamp);
    }
}
