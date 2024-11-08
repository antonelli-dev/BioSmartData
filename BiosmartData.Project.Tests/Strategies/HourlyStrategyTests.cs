using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using BiosmartData.Project.Application.Strategies;
using BiosmartData.Project.Domain.Entities;
using BiosmartData.Project.Domain.Enums;
using BiosmartData.Project.Application.Interfaces;

namespace BiosmartData.Project.Tests.Strategies
{
    public class HourlyStrategyTests
    {
        [Fact]
        public void Display_ShouldNotThrow_WhenNoEvents()
        {
            var events = new List<IChatEvent>();
            var strategy = new MinuteByMinuteStrategy();

            var exception = Record.Exception(() => strategy.Display(events));
            Assert.Null(exception); 
        }
        [Fact]
        public void Display_ShouldHandleSingleEvent()
        {
            var events = new List<IChatEvent>
            {
                new EnterRoomEvent(TimeSpan.FromHours(8), "User1")
            };
            var strategy = new MinuteByMinuteStrategy();

            var exception = Record.Exception(() => strategy.Display(events));
            Assert.Null(exception);
        }
    }
}