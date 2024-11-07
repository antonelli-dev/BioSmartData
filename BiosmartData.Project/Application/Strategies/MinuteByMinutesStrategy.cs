using BiosmartData.Project.Application.Interfaces;
using BiosmartData.Project.Domain.Entities;
using BiosmartData.Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiosmartData.Project.Application.Strategies
{
    public class MinuteByMinuteStrategy : IAggregationStrategy
    {
        public void Display(IEnumerable<IChatEvent> events)
        {
            if (!events.Any())
            {
                Console.WriteLine("No events found");
                return;
            }

            foreach (var chatEvent in events.OrderBy(e => e.Time))
            {
                var formattedTime = DateTime.Today.Add(chatEvent.Time).ToString("h:mm tt");
                Console.WriteLine($"{formattedTime}: {chatEvent.User} {GetEventDescription(chatEvent)}");
            }
        }

        private string GetEventDescription(IChatEvent chatEvent)
        {
            return chatEvent.EventType switch
            {
                EventType.EnterRoom => "enters the room",
                EventType.LeaveRoom => "leaves",
                EventType.Comment => $"comments: \"{((CommentEvent)chatEvent).Message}\"",
                EventType.HighFive => $"high-fives {((HighFiveEvent)chatEvent).TargetUser}",
                _ => "unknown event"
            };
        }
    }


}
