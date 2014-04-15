using System;

namespace DateGroup
{
    public class GroupByWeek:IGroupBy
    {
        public DateTime DateAtIndex(DateTime start, int index)
        {
            // TODO: Normalize on start of week.
            return start.AddDays(7*index);
        }

        public int IndexAtDate(DateTime startDate, DateTime atDate)
        {
            return (int) Math.Floor(atDate.Subtract(startDate).TotalDays/7);
        }
    }
}
