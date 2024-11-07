using BiosmartData.Project.Domain.Entities;
using System;
using Xunit;

namespace BiosmartData.Project.Tests.Domain.Entities
{
    public class HighFiveEventTests
    {
        [Fact]
        public void HighFiveEvent_ShouldInitializeWithCorrectUserAndTargetUser()
        {
            var highFiveEvent = new HighFiveEvent(new TimeSpan(8, 20, 0), "Alice", "Bob");

            Assert.Equal("Alice", highFiveEvent.User);
            Assert.Equal("Bob", highFiveEvent.TargetUser);
            Assert.Equal(new TimeSpan(8, 20, 0), highFiveEvent.Time);
        }
    }
}
