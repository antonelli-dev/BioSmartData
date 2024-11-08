using BiosmartData.Project.Application.Interfaces;
using BiosmartData.Project.Application.Strategies;
using BiosmartData.Project.Domain.Entities;


namespace BiosmartData.Project.Tests.Strategies
{
    public class MinuteByMinuteStrategyTests
    {
       

        [Fact]
        public void Display_ShouldHandleSingleEnterEvent()
        {
            var events = new List<IChatEvent>
            {
                new EnterRoomEvent(TimeSpan.FromHours(8), "User1")
            };
            var strategy = new MinuteByMinuteStrategy();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                strategy.Display(events);

                var result = sw.ToString();
                Assert.Contains("8:00 AM: User1 enters the room", result);
            }
        }

        [Fact]
        public void Display_ShouldGroupEventsByMinuteCorrectly()
        {
            var events = new List<IChatEvent>
            {
                new EnterRoomEvent(TimeSpan.FromHours(8), "User1"),
                new CommentEvent(TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(15)), "User2", "Good morning!"),
                new LeaveRoomEvent(TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(30)), "User1"),
                new HighFiveEvent(TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(45)), "User1", "User2")
            };
            var strategy = new MinuteByMinuteStrategy();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                strategy.Display(events);

                var result = sw.ToString();
                Assert.Contains("8:00 AM: User1 enters the room", result);
                Assert.Contains("8:15 AM: User2 comments: \"Good morning!\"", result);
                Assert.Contains("8:30 AM: User1 leaves", result);
                Assert.Contains("8:45 AM: User1 high-fives User2", result);
            }
        }

      
    }
}
