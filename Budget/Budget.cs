
using System;
using System.Globalization;

namespace Budget
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int    Amount    { get; set; }
        
        public DateTime FirstDay()
        {
            var dateTime = DateTime.ParseExact($"{YearMonth}", "yyyyMM", CultureInfo.InvariantCulture);
            return dateTime;
        }

        public int Days()
        {
            var daysInMonth = DateTime.DaysInMonth(FirstDay().Year, FirstDay().Month);
            return daysInMonth;
        }

        public DateTime LastDay()
        {
            return new DateTime(FirstDay().Year, FirstDay().Month, Days());
        }

        public int DailyAmount()
        {
            return Amount / Days();
        }

        public Period CreatePeriod()
        {
            return new Period(FirstDay(), LastDay());
        }

        public int OverlappingAmount(Period period)
        {
            return DailyAmount() * period.OverlappingDays( CreatePeriod());
        }
    }
}