using System;
using System.Globalization;

namespace Daneshgah.MethodHa.TabdilTarikh//برای این که در سطح برنامه از تاریخ میلادی استفاده میشود نیاز است توسط یک متد به شمسی تبدیل شود که متد های این کلاس این کار رو میکنن
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00") + "    " + pc.GetHour(value) + ":" + pc.GetMinute(value) + ":" + pc.GetSecond(value).ToString("00");

        }
        public static string ToShamsiCalender(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00");

        }
        public static DateTime ToMiladi(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new System.Globalization.PersianCalendar());
        }
    }
}
