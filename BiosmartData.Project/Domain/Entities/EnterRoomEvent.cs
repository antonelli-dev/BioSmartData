using BiosmartData.Project.Domain.Enums;
using System;

namespace BiosmartData.Project.Domain.Entities
{
    public class EnterRoomEvent : BaseChatEvent
    {
        public EnterRoomEvent(TimeSpan time, string user)
            : base(EventType.EnterRoom, time, user) { }
    }
}
