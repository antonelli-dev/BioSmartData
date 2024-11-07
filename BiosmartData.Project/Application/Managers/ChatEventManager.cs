using BiosmartData.Project.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiosmartData.Project.Application.Managers
{
    public class ChatEventManager : IChatEventManager
    {
        private readonly List<IChatEvent> _events = new();

        public void AddEvent(IChatEvent chatEvent)
        {
            _events.Add(chatEvent);
        }

        public IEnumerable<IChatEvent> GetEvents()
        {
            return _events.AsReadOnly();
        }

        public void DisplayAggregatedEvents(IAggregationStrategy strategy)
        {
            if (!_events.Any())
            {
                Console.WriteLine("No events found");
                return;
            }
            strategy.Display(_events);
        }
    }
}
