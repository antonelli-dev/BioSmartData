using BiosmartData.Project.Application.Managers;
using BiosmartData.Project.Application.Strategies;
using BiosmartData.Project.Domain.Entities;

namespace BiosmartData.Project.Tests.Managers
{
    public class ChatEventManagerTests : IDisposable
    {
        private readonly TextWriter _originalConsoleOut;

        public ChatEventManagerTests()
        {
            _originalConsoleOut = Console.Out;
        }

        [Fact]
        public void AddEvent_ShouldAddEventToEventList()
        {
            var chatEventManager = new ChatEventManager();
            var eventTime = new TimeSpan(8, 0, 0);
            var newEvent = new EnterRoomEvent(eventTime, "Alice");

            chatEventManager.AddEvent(newEvent);
            var events = chatEventManager.GetEvents().ToList();

            Assert.Single(events);
            Assert.Equal("Alice", ((EnterRoomEvent)events[0]).User);
        }

        [Fact]
        public void DisplayAggregatedEvents_ShouldShowNoEventsMessageWhenEmpty()
        {
            var chatEventManager = new ChatEventManager();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                chatEventManager.DisplayAggregatedEvents(new MinuteByMinuteStrategy());

                var result = sw.ToString();
                Assert.Contains("No events found", result);
            }
        }

        [Fact]
        public void AddEvent_ShouldAddMultipleEventsToEventList()
        {
            var chatEventManager = new ChatEventManager();
            var event1 = new EnterRoomEvent(new TimeSpan(8, 0, 0), "Alice");
            var event2 = new CommentEvent(new TimeSpan(8, 5, 0), "Bob", "Hello!");

            chatEventManager.AddEvent(event1);
            chatEventManager.AddEvent(event2);
            var events = chatEventManager.GetEvents().ToList();

            Assert.Equal(2, events.Count);
            Assert.Equal("Alice", ((EnterRoomEvent)events[0]).User);
            Assert.Equal("Bob", ((CommentEvent)events[1]).User);
            Assert.Equal("Hello!", ((CommentEvent)events[1]).Message);
        }


        public void Dispose()
        {
            Console.SetOut(_originalConsoleOut);
        }
    }
}
