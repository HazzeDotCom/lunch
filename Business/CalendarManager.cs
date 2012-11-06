using System;
using System.Globalization;

namespace Business
{
    public static class CalendarManager
    {
        public static string GetDay(DateTime dt)
        {
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Måndag";
                case DayOfWeek.Tuesday:
                    return "Tisdag";
                case DayOfWeek.Wednesday:
                    return "Onsdag";
                case DayOfWeek.Thursday:
                    return "Torsdag";
                case DayOfWeek.Friday:
                    return "Fredag";
                case DayOfWeek.Saturday:
                    return "Lördag";
                case DayOfWeek.Sunday:
                    return "Lördag";
                default:
                    return "Måndag";
            }
        }
        
        public static string GetMonth(DateTime dt)
        {
            switch (dt.Month)
            {
                case 1:
                    return "Januari";
                case 2:
                    return "Februari";
                case 3:
                    return "Mars";
                case 4:
                    return "April";
                case 5:
                    return "Maj";
                case 6:
                    return "Juni";
                case 7:
                    return "Juli";
                case 8:
                    return "Augusti";
                case 9:
                    return "September";
                case 10:
                    return "Oktober";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "Januari";
            }
        }
    
        public static string GetTodayAsTextinfo()
        {
            var now = DateTime.Now;
            var today = GetDay(now);
            return string.Format("{0} {1} {2}", today.ToLower(), now.Day, GetMonth(now).ToLower());
        }
        
        public static string GetTodaysName()
        {
            var now = DateTime.Now;
            return GetDay(now);
        }
        
        public static int GetTodaysDate()
        {
            var now = DateTime.Now;
            return now.Day;
        }

        public static int GetCurrentWeek()
        {
            var now = DateTime.Now;
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}