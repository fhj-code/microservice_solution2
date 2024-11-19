using microservice_solution2.Models;
using System.Collections.Generic;

namespace microservice_solution2
{
    public interface IActivityLogger
    {
        IEnumerable<LogEvent> Get(long timestamp);
    }
}
