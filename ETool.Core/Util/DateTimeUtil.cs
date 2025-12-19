using System;
using System.Globalization;

namespace ETool.Core.Util
{
    /// <summary>
    /// 日期时间工具类
    /// </summary>
    public static class DateTimeUtil
    {
        /// <summary>
        /// 判断指定字符串是否符合指定格式的日期时间字符串
        /// </summary>
        /// <param name="s">待校验的字符串</param>
        /// <param name="format">格式</param>
        /// <returns>如果字符串符合返回 true，否则返回 false</returns>
        public static bool IsValidDateTime(string s, string format)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(format))
            {
                return false;
            }

            return DateTime.TryParseExact(s, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        /// <summary>
        /// 从指定格式的日期字符串中解析该日期是该年中的第几天（1-366）
        /// </summary>
        /// <param name="s">要解析的日期字符串</param>
        /// <param name="formats">用于解析的日期格式字符串数组</param>
        /// <returns> 解析成功时，返回该日期在一年中的第几天；解析失败时，返回 -1 </returns>
        public static int GetDayOfYear(string s, string[] formats)
        {
            if (!DateTime.TryParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
            {
                return -1;
            }

            return dateTime.DayOfYear;
        }

        /// <summary>
        /// 判断 DateTime 是否在指定的起止日期时间内（包含边界）
        /// </summary>
        /// <param name="dt">要判断的日期时间</param>
        /// <param name="start">开始日期时间</param>
        /// <param name="end">结束日期时间</param>
        /// <returns>如果指定日期时间在指定的起止日期时间范围内，返回 true；否则返回 false</returns>
        public static bool BetweenDateTime(DateTime dt, DateTime start, DateTime end)
        {
            if (start > end)
            {
                (start, end) = (end, start);
            }

            return dt >= start && dt <= end;
        }

        /// <summary>
        /// 判断 DateTime 是否在指定的起止日期内（包含边界）
        /// </summary>
        /// <param name="dt">要判断的日期</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns>如果指定日期在指定的起止日期范围内，返回 true；否则返回 false</returns>
        public static bool BetweenDate(DateTime dt, DateTime start, DateTime end)
        {
            if (start > end)
            {
                (start, end) = (end, start);
            }

            return dt.Date >= start.Date && dt.Date <= end.Date;
        }
    }
}
