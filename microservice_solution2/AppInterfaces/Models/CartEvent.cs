namespace microservice_solution2.Models
{
    public class CartEvent: EventBase
    {
        public CartEventTypeEnum Type { get; set; }
        public Order Order { get; set; }
    }
}
