using System.Collections.Generic;

namespace BiosmartData.Project.Application.Interfaces
{
    public interface IChatEventManager
    {
        void AddEvent(IChatEvent chatEvent);
        void DisplayAggregatedEvents(IAggregationStrategy strategy);
        IEnumerable<IChatEvent> GetEvents();
    }
}
