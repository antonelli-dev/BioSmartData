using System.Collections.Generic;

namespace BiosmartData.Project.Application.Interfaces
{
    public interface IAggregationStrategy
    {
        void Display(IEnumerable<IChatEvent> events);
    }
}
