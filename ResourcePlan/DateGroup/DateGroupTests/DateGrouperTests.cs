using System;
using System.Collections.Generic;
using DateGroup;
using DateGroup.SampleItems;
using NUnit.Framework;
using SharpTestsEx;

namespace DateGroupTests
{
    [TestFixture]
    public class DateGrouperTests
    {
        [Test]
        public void Should_get_groups_by_week()
        {
            var grouper = new DateGrouper(new GroupByWeek());
            var startDate = new DateTime(2014, 04, 06); // TODO: Normalize to start of week
            var groups = grouper.GetGroups(startDate, startDate.AddDays(20));
            groups.Count.Should().Be(3);
        }

        [Test]
        public void Should_group_data_by_week()
        {
            var startDate = new DateTime(2014, 04, 06);
            var data = new List<TimelinePart>()
                {
                    new TimelinePart {Date = startDate, Units = 1},
                    new TimelinePart {Date = startDate.AddDays(4), Units = 2},
                    new TimelinePart {Date = startDate.AddDays(20), Units = 3},
                };

            var grouper = new DateGrouper(new GroupByWeek());
            var result = grouper.GroupData(data);
            result.Count.Should().Be(3);
            result[0].Items.Count.Should().Be(2);
            result[1].Items.Count.Should().Be(0);
            result[2].Items.Count.Should().Be(1);
        }
    }
}
