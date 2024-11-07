using BiosmartData.Project.Domain.Enums;
using System;

namespace BiosmartData.Project.Application.Interfaces
{
    public interface IChatEvent
    {
        EventType EventType { get; }
        TimeSpan Time { get; }
        string User { get; }
    }
}
