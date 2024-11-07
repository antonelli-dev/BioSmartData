using BiosmartData.Project.Application.Interfaces;
using BiosmartData.Project.Domain.Entities;
using BiosmartData.Project.Domain.Enums;


namespace BiosmartData.Project.Application.Strategies
{
    public class HourlyStrategy : IAggregationStrategy
    {
        public void Display(IEnumerable<IChatEvent> events)
        {

            if (!events.Any())
            {
                Console.WriteLine("No events found");
                return;
            }

            var groupedEvents = events
                .GroupBy(e => DateTime.Today.Add(e.Time).ToString("h tt"))
                .OrderBy(g => g.Key);
                
            foreach (var group in groupedEvents)
            {
                Console.WriteLine($"{group.Key}:");

                int enterRoomCount = group.Count(e => e.EventType == EventType.EnterRoom);
                int leaveRoomCount = group.Count(e => e.EventType == EventType.LeaveRoom);
                int commentCount = group.Count(e => e.EventType == EventType.Comment);

                IReadOnlyList<HighFiveEvent> highFiveEvents = events
                    .Where(x => TimeFormatter.FormatHourly(x.Time) == group.Key)
                    .OfType<HighFiveEvent>()
                    .ToList();

                int highFiveFrom = highFiveEvents.Select(x => x.User).Distinct().Count();
                int highFiveTo = highFiveEvents.Select(x => x.TargetUser).Distinct().Count();

                if (enterRoomCount > 0)
                    Console.WriteLine($"\t{enterRoomCount} {(enterRoomCount > 1 ? "people" : "person")} entered");
                if (leaveRoomCount > 0)
                    Console.WriteLine($"\t{leaveRoomCount} left");
                if (commentCount > 0)
                    Console.WriteLine($"\t{commentCount} comment{(commentCount > 1 ? "s" : "")}");
                if (highFiveFrom > 0)
                    Console.WriteLine($"\t{highFiveFrom} high-five{(highFiveFrom > 1 ? "s" : "")} to {highFiveTo} other {( highFiveTo > 1 ? "people" : "person" )}");
            }
        }
    }

}
