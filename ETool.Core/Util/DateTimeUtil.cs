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
        /// 将日期按照指定格式转换成字符串
        /// </summary>
        /// <param name="date">要格式化的日期</param>
        /// <param name="format">日期格式字符串</param>
        /// <returns>格式化后的日期字符串</returns>
        public static string FormatToString(DateTime date, string format)
        {
            return date.ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 将日期时间字符串从一种格式转换为另一种格式
        /// </summary>
        /// <param name="inputDatetime">输入的日期字符串</param>
        /// <param name="inputFormat">用于解析输入字符串的日期格式</param>
        /// <param name="outputFormat">用于格式化输出的日期格式</param>
        /// <returns>格式化后的日期字符串</returns>
        /// <exception cref="ArgumentException"><c>inputDatetime == null || inputDatetime == ""</c></exception>
        /// <exception cref="ArgumentException"><c>inputFormat == null || inputFormat == ""</c></exception>
        /// <exception cref="ArgumentException"><c>outputFormat == null || outputFormat == ""</c></exception>
        /// <exception cref="FormatException">字符串 <c>inputDatetime</c> 无法按指定格式 <c>inputFormat</c> 解析为有效日期</exception>
        public static string FormatToString(string inputDatetime, string inputFormat, string outputFormat)
        {
            var dateTime = FormatToDateTime(inputDatetime, inputFormat);
            return FormatToString(dateTime, outputFormat);
        }

        /// <summary>
        /// 将毫秒时间戳转换为指定格式的日期字符串（自 1970-01-01 UTC 起）
        /// </summary>
        /// <param name="millSeconds">毫秒时间戳</param>
        /// <param name="format">目标日期格式字符串</param>
        /// <returns>格式化后的日期字符串（使用 UTC 时间）</returns>
        /// <exception cref="ArgumentOutOfRangeException">millSeconds 小于 -62_135_596_800_000L 或者大于 253_402_300_799_999L</exception>
        public static string FormatToString(long millSeconds, string format)
        {
            const long minSupportedMilliseconds = -62_135_596_800_000L;
            const long maxSupportedMilliseconds = 253_402_300_799_999L;

            if (millSeconds < minSupportedMilliseconds || millSeconds > maxSupportedMilliseconds)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(millSeconds),
                    millSeconds,
                    $"毫秒时间戳 '{nameof(millSeconds)}' 必须介于 {minSupportedMilliseconds} 和 {maxSupportedMilliseconds} 之间（对应 UTC 日期 0001-01-01 至 9999-12-31），实际值：{millSeconds}");
            }

            var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(millSeconds).DateTime;
            return FormatToString(dateTime, format);
        }

        /// <summary>
        /// 将字符串按照 format 格式转换成日期类型
        /// </summary>
        /// <param name="s">要解析的日期字符串</param>
        /// <param name="formats">用于解析的一个或多个日期格式字符串</param>
        /// <returns>解析得到的 DateTime 对象</returns>
        /// <exception cref="ArgumentException"><c>s == null || s == ""</c></exception>
        /// <exception cref="ArgumentException"><c>formats == null || formats.Length == 0</c></exception>
        /// <exception cref="FormatException">字符串 <c>s</c> 无法按 <c>formats</c> 提供的任一格式解析为有效日期</exception>
        public static DateTime FormatToDateTime(string s, params string[] formats)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException($"日期字符串 '{nameof(s)}' 不能为 null 或空，实际值：{(s == null ? "null" : "\"\"")}", nameof(s));
            }

            if (formats == null || formats.Length == 0)
            {
                throw new ArgumentException($"日期格式字符串 '{nameof(formats)}' 至少提供一个参数，实际值：{(formats == null ? "null" : "[]")}", nameof(formats));
            }

            if (!DateTime.TryParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
            {
                var formatList = StrUtil.Join(',', formats, false);
                throw new FormatException($"无法将字符串 '{s}' 按照格式 '{formatList}' 解析为有效的 DateTime");
            }

            return dateTime;
        }

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
        /// 从指定格式的日期字符串中解析该日期是一年中的第几天
        /// </summary>
        /// <param name="s">要解析的日期字符串</param>
        /// <param name="formats">用于解析的一个或多个日期格式字符串</param>
        /// <returns>返回该日期在一年中的第几天（范围：1 到 366）</returns>
        /// <exception cref="ArgumentException"><c>s == null || s == ""</c></exception>
        /// <exception cref="ArgumentException"><c>formats == null || formats.Length == 0</c></exception>
        /// <exception cref="FormatException">字符串 <c>s</c> 无法按 <c>formats</c> 提供的任一格式解析为有效日期</exception>
        public static int GetDayOfYear(string s, params string[] formats)
        {
            return FormatToDateTime(s, formats).DayOfYear;
        }

        /// <summary>
        /// 从指定格式的日期字符串中解析该日期是当前周中的第几天
        /// </summary>
        /// <param name="s">要解析的日期字符串</param>
        /// <param name="formats">用于解析的一个或多个日期格式字符串</param>
        /// <returns>返回该日期在当前周中的第几天（范围：1 到 7）</returns>
        /// <exception cref="ArgumentException"><c>s == null || s == ""</c></exception>
        /// <exception cref="ArgumentException"><c>formats == null || formats.Length == 0</c></exception>
        /// <exception cref="FormatException">字符串 <c>s</c> 无法按 <c>formats</c> 提供的任一格式解析为有效日期</exception>
        public static int GetDayOfWeek(string s, params string[] formats)
        {
            var dayOfWeek = FormatToDateTime(s, formats).DayOfWeek;
            return dayOfWeek == DayOfWeek.Sunday ? 7 : (int)dayOfWeek;
        }

        /// <summary>
        /// 从指定格式的日期字符串中解析该日期是当前月中的第几天
        /// </summary>
        /// <param name="s">要解析的日期字符串</param>
        /// <param name="formats">用于解析的一个或多个日期格式字符串</param>
        /// <returns>返回该日期在当前月中的第几天（范围：1 到 31）</returns>
        /// <exception cref="ArgumentException"><c>s == null || s == ""</c></exception>
        /// <exception cref="ArgumentException"><c>formats == null || formats.Length == 0</c></exception>
        /// <exception cref="FormatException">字符串 <c>s</c> 无法按 <c>formats</c> 提供的任一格式解析为有效日期</exception>
        public static int GetDayOfMonth(string s, params string[] formats)
        {
            return FormatToDateTime(s, formats).Day;
        }

        /// <summary>
        /// 从指定格式的日期字符串中解析该日期是当前年中的第几个月
        /// </summary>
        /// <param name="s">要解析的日期字符串</param>
        /// <param name="formats">用于解析的一个或多个日期格式字符串</param>
        /// <returns>返回该日期在当前年中的第几个月（范围：1 到 12）</returns>
        /// <exception cref="ArgumentException"><c>s == null || s == ""</c></exception>
        /// <exception cref="ArgumentException"><c>formats == null || formats.Length == 0</c></exception>
        /// <exception cref="FormatException">字符串 <c>s</c> 无法按 <c>formats</c> 提供的任一格式解析为有效日期</exception>
        public static int GetMonthOfYear(string s, params string[] formats)
        {
            return FormatToDateTime(s, formats).Month;
        }

        /// <summary>
        /// 从指定格式的日期字符串中解析该日期是哪一年
        /// </summary>
        /// <param name="s">要解析的日期字符串</param>
        /// <param name="formats">用于解析的一个或多个日期格式字符串</param>
        /// <returns>返回该日期是哪一年（范围：1-9999）</returns>
        /// <exception cref="ArgumentException"><c>s == null || s == ""</c></exception>
        /// <exception cref="ArgumentException"><c>formats == null || formats.Length == 0</c></exception>
        /// <exception cref="FormatException">字符串 <c>s</c> 无法按 <c>formats</c> 提供的任一格式解析为有效日期</exception>
        public static int GetYear(string s, params string[] formats)
        {
            return FormatToDateTime(s, formats).Year;
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
