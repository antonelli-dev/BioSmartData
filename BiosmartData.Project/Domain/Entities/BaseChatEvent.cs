using BiosmartData.Project.Application.Interfaces;
using BiosmartData.Project.Domain.Enums;
using System;

namespace BiosmartData.Project.Domain.Entities
{
    public abstract class BaseChatEvent : IChatEvent
    {
        public EventType EventType { get; }
        public TimeSpan Time { get; }
        public string User { get; }

        protected BaseChatEvent(EventType eventType, TimeSpan time, string user)
        {
            EventType = eventType;
            Time = time;
            User = user;
        }
    }
}
