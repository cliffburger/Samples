using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DateGroup
{
    public class DateGrouper
    {
        private readonly IGroupBy _groupBy;

        public DateGrouper(IGroupBy groupBy)
        {
            _groupBy = groupBy;
        }

        /// <summary>
        /// E.g. Return a list of date groups between the start and end.
        /// </summary>
        public IList<DateGroup> GetGroups(DateTime startDate, DateTime endDate)
        {
            var list = new List<DateGroup>();

            int index = 0;
            var nextDate = _groupBy.DateAtIndex(startDate, index);
            while (nextDate <= endDate)
            {
                var newGroup = new DateGroup {Index = index, Start = nextDate};
                index++;
                nextDate = _groupBy.DateAtIndex(startDate, index);
                newGroup.End = nextDate.AddDays(-1);
                list.Add(newGroup);
            }
            return list;
        }

        public IList<DateGroupList<T>> GroupData<T>(IEnumerable<T> data) where T : IDateGroupable
        {
            var dataList = data.ToList();
            var minDate = dataList.Min(d => d.Date);
            var maxDate = dataList.Max(d => d.Date);
            return GroupData(dataList, minDate, maxDate);
        }

        public IList<DateGroupList<T>> GroupData<T>(IEnumerable<T> data, DateTime startDate, DateTime endDate) where T : IDateGroupable
        {
            List<DateGroupList<T>> groups = GetGroups(startDate, endDate)
                .Select(g => new DateGroupList<T> {Start = g.Start, End = g.End, Index = g.Index, Items = new List<T>()})
                .OrderBy(g => g.Index) 
                .ToList();

             foreach (var item in data)
             {
                 groups[_groupBy.IndexAtDate(startDate, item.Date)].Items.Add(item);
             }

             return groups;
         }

        public IList<DateGroupList<T>> GroupDataFunky<T>(IEnumerable<T> data, DateTime startDate, DateTime endDate, Func<T, DateTime> getDateFromT) 
        {
            List<DateGroupList<T>> groups = GetGroups(startDate, endDate)
                .Select(g => new DateGroupList<T> { Start = g.Start, End = g.End, Index = g.Index, Items = new List<T>() })
                .OrderBy(g => g.Index)
                .ToList();

            foreach (var item in data)
            {
                groups[_groupBy.IndexAtDate(startDate, getDateFromT(item))].Items.Add(item);
            }

            return groups;
        }

        public IList<DateGroupList<T>> GroupDataAllen<T>(IEnumerable<T> data, DateTime startDate, DateTime endDate) where T : IDateGroupable
        {
            List<DateGroupList<T>> groups = GetGroups(startDate, endDate)
                .Select(g => new DateGroupList<T> { Start = g.Start, End = g.End, Index = g.Index, Items = new List<T>() })
                .OrderBy(g => g.Start)
                .ToList();

            var counter = 0;
            DateGroupList<T> currentGroup = groups[0];
            foreach (var item in data)
            {
                while (counter < groups.Count && NotInDateRange(item.Date, currentGroup.Start, currentGroup.End))
                {
                    currentGroup = groups[++counter];
                }
                if (currentGroup == null)
                {
                    throw new Exception("Your data is outside the bounds of your groups collection...is this ok??");//we can't bucket items in the list
                }
                currentGroup.Items.Add(item);
            }

            return groups;
        }


        private bool NotInDateRange(DateTime containedDate, DateTime start, DateTime end)
        {
            return !(start >= containedDate && containedDate < end);
        }
    }

    public interface IGroupBy
    {
        DateTime DateAtIndex(DateTime startDate, int index);
        int IndexAtDate(DateTime startDate, DateTime atDate);
    }

    public class DateGroup
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Index { get; set; }
    }

    public class DateGroupList<T> : DateGroup 
    {
        public IList<T> Items { get; set; }
    }

    public interface IDateGroupable
    {
        DateTime Date { get; }
    }
}
