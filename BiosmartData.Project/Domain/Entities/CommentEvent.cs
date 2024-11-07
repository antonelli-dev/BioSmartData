using BiosmartData.Project.Domain.Enums;
using System;

namespace BiosmartData.Project.Domain.Entities
{
    public class CommentEvent : BaseChatEvent
    {
        public string Message { get; }

        public CommentEvent(TimeSpan time, string user, string message)
            : base(EventType.Comment, time, user)
        {
            Message = message;
        }
    }
}
