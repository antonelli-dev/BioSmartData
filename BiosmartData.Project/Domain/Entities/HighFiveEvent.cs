using BiosmartData.Project.Domain.Enums;
using System;

namespace BiosmartData.Project.Domain.Entities
{
    public class HighFiveEvent : BaseChatEvent
    {
        public string TargetUser { get; }

        public HighFiveEvent(TimeSpan time, string user, string targetUser)
            : base(EventType.HighFive, time, user)
        {
            TargetUser = targetUser;
        }
    }
}
