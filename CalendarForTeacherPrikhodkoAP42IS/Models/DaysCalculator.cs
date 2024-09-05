using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarForTeacherPrikhodkoAP42IS.Models
{
    public class DaysCalculator
    {
        private static HashSet<DateTime> GetHolidays(int year)
        {
            List<Holyday> holydays = ConnetWithjson.getHolydays();

            HashSet<DateTime> NormalHolydays = new HashSet<DateTime>();
            foreach (Holyday holyday in holydays)
            {
                if (holyday.Month < DateTime.Now.Month)
                {
                    NormalHolydays.Add(new DateTime(year + 1, holyday.Month, holyday.Day));

                }
                else
                {
                    NormalHolydays.Add(new DateTime(year, holyday.Month, holyday.Day));
                }
            }
            return NormalHolydays;
        }

        public static int DaysUntilSummer(DateTime currentDate)
        {
            DateTime summerStartDate = new DateTime(currentDate.Year, 6, 1);

            if (currentDate >= summerStartDate)
            {
                summerStartDate = new DateTime(currentDate.Year + 1, 6, 1);
            }
            HashSet<DateTime> holidays = GetHolidays(currentDate.Year);
            int workDays = 0;

            for (DateTime date = currentDate; date < summerStartDate; date = date.AddDays(1))
            {
                if (WorkableDay(date, holidays))
                {
                    workDays++;
                }
            }
            return workDays;
        }

        public static int HoursUntilSummer(DateTime currentDate)
        {
            int workDays = DaysUntilSummer(currentDate);
            int currentHour = currentDate.Hour;
            return (workDays - 1) * 24 + (24 - currentHour);
        }

        public static int MinutesUntilSummer(DateTime currentDate)
        {
            int workHours = HoursUntilSummer(currentDate);
            int currentMinute = currentDate.Minute;
            return (workHours - 1) * 60 + (60 - currentMinute);
        }

        public static int SecondsUntilSummer(DateTime currentDate)
        {
            int workMinutes = MinutesUntilSummer(currentDate);
            int currentSecond = currentDate.Second;
            return (workMinutes - 1) * 60 + (60 - currentSecond);
        }

        private static bool WorkableDay(DateTime date, HashSet<DateTime> holidays)
        {
            return date.DayOfWeek != DayOfWeek.Saturday &&
                   date.DayOfWeek != DayOfWeek.Sunday &&
                   !holidays.Contains(date.Date);
        }
    }

}
