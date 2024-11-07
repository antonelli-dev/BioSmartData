using BiosmartData.Project.Domain.Enums;
using System;

namespace BiosmartData.Project.Domain.Entities
{
    public class LeaveRoomEvent : BaseChatEvent
    {
        public LeaveRoomEvent(TimeSpan time, string user)
            : base(EventType.LeaveRoom, time, user) { }
    }
}
