using System;
using System.Collections.Generic;
using System.Linq;

namespace Workshop2019.EmployeeApi
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public WorkLogItem[] StandingOutWorkItems { get; set; }

        public WorkLogItem[] GetWorkItems(DateTime fromDateTime, DateTime toDateTime)
        {
            var requestedDates = GetDates(fromDateTime.Date, toDateTime.Date)
                .ToArray();

            return requestedDates
                .Select(GetWorkLogItem)
                .ToArray();
        }

        private IEnumerable<DateTime> GetDates(DateTime from, DateTime to)
        {
            if (from > to)
            {
                throw new InvalidOperationException($"From date ({from}) cannot be later than to date ({to}).");
            }

            return IterateDates().ToArray();

            IEnumerable<DateTime> IterateDates()
            {
                for (var currentDate = from; currentDate <= to; currentDate = currentDate.AddDays(1))
                {
                    yield return currentDate;
                }
            }
        }

        private WorkLogItem GetWorkLogItem(DateTime date)
        {
            var foundWorkItemOrNull = StandingOutWorkItems.FirstOrDefault(workItem => workItem.Date.Date == date);

            return foundWorkItemOrNull ?? DefaultWorkLogItem(date);
        }

        private WorkLogItem DefaultWorkLogItem(DateTime date)
        {
            return new WorkLogItem
            {
                Date = date,
                WorkedHours = IsWeekend(date) ? 0 : 8
            };
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public class WorkLogItem
    {
        public DateTime Date { get; set; }
        public decimal WorkedHours { get; set; }
    }
}