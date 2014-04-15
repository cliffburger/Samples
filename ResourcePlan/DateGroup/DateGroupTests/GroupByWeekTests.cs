using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateGroup;
using NUnit.Framework;
using SharpTestsEx;

namespace DateGroupTests
{
    [TestFixture]
    public class GroupByWeekTests
    {
        [Test]
        public void IndexAtDateTest()
        {
            var startDate = new DateTime(2014, 05, 01);
            new GroupByWeek().IndexAtDate(startDate, startDate).Should().Be(0);
            new GroupByWeek().IndexAtDate(startDate, startDate.AddDays(6)).Should().Be(0);
            new GroupByWeek().IndexAtDate(startDate, startDate.AddDays(8)).Should().Be(1);
        }
    }
}
