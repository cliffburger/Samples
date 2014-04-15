using System;

namespace DateGroup.SampleItems
{
    public class TimelinePart:IDateGroupable
    {
        public decimal Units { get; set; }
        public DateTime Date { get; set; }
    }
}
