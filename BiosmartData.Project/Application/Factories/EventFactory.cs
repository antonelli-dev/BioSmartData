using BiosmartData.Project.Application.Interfaces;
using BiosmartData.Project.Domain.Entities;
using BiosmartData.Project.Domain.Enums;

public static class EventFactory
{
    public static IChatEvent CreateEvent(EventType eventType, TimeSpan time, string user, string? message = null, string? targetUser = null)
    {
        return eventType switch
        {
            EventType.EnterRoom => new EnterRoomEvent(time, user),
            EventType.LeaveRoom => new LeaveRoomEvent(time, user),
            EventType.Comment => new CommentEvent(time, user, message ?? string.Empty),
            EventType.HighFive => new HighFiveEvent(time, user, targetUser ?? string.Empty),
            _ => throw new ArgumentException("Unsupported event type")
        };
    }
}
