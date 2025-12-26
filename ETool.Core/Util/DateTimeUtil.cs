using System;
using System.Collections.Generic;
using System.Globalization;

namespace ETool.Core.Util
{
    /// <summary>
    /// 日期时间工具类
    /// </summary>
    public static class DateTimeUtil
    {
        /// <summary>
        /// 将字符串按照 format 格式转换成日期类型
        /// </summary>
        /// <param name="s">要解析的日期字符串</param>
        /// <param name="formats">用于解析的日期格式字符串数组</param>
        /// <returns>解析得到的 DateTime 对象</returns>
        /// <exception cref="ArgumentException"><c>s</c> 为 null 或空字符串</exception>
        /// <exception cref="ArgumentException"><c>formats</c> 为 null 或空数组</exception>
        /// <exception cref="ArgumentException"><c>formats</c> 所有元素均为 null 或空字符串</exception>
        /// <exception cref="FormatException">字符串 <c>s</c> 无法按照 <c>formats</c> 中的任一格式解析为有效的日期</exception>
        /// <remarks>本方法不处理 DateTimeKind 属性</remarks>
        public static DateTime FormatToDateTime(string s, params string[] formats)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException($"日期字符串不能为 null 或空，实际值：{(s == null ? "null" : "\"\"")}", nameof(s));
            }

            if (formats == null || formats.Length == 0)
            {
                throw new ArgumentException($"日期格式字符串数组至少需要提供一个参数，实际值：{(formats == null ? "null" : "[]")}", nameof(formats));
            }

            var list = new List<string>(formats.Length);
            foreach (var format in formats)
            {
                if (!string.IsNullOrEmpty(format))
                {
                    list.Add(format);
                }
            }

            if (list.Count == 0)
            {
                throw new ArgumentException("所有提供的日期格式均为 null 或空字符串", nameof(formats));
            }

            formats = list.ToArray();

            if (!DateTime.TryParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
            {
                throw new FormatException($"无法将字符串 '{s}' 按照 '[{string.Join(", ", formats)}]' 提供的格式解析为有效的 DateTime");
            }

            return dateTime;
        }

        /// <summary>
        /// 将日期按照指定格式转换成字符串
        /// </summary>
        /// <param name="datetime">要格式化日期</param>
        /// <param name="format">日期格式字符串</param>
        /// <returns>格式化后的日期字符串</returns>
        /// <remarks>
        /// 1. 本方法不处理 DateTimeKind 属性<br/>
        /// 2. 本方法根据 datetime 内部数值直接格式化，不涉及任何时区的处理<br/>
        /// 3. 输出结果仅反映 datetime 的字面值，与其 DateTimeKind 属性无关
        /// </remarks>
        public static string FormatToString(DateTime datetime, string format)
        {
            return datetime.ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 将日期时间字符串从一种格式转换为另一种格式
        /// </summary>
        /// <param name="inputDateTime">输入的日期字符串</param>
        /// <param name="inputFormat">解析输入字符串的日期格式</param>
        /// <param name="outputFormat">格式化输出字符串的日期格式</param>
        /// <exception cref="ArgumentException"><c>inputDateTime</c> 为 null 或空字符串</exception>
        /// <exception cref="ArgumentException"><c>inputFormat</c> 为 null 或空字符串</exception>
        /// <exception cref="ArgumentException"><c>outputFormat</c> 为 null 或空字符串</exception>
        /// <exception cref="FormatException"><c>inputDateTime</c> 不是有效的日期格式字符串</exception>
        /// <exception cref="FormatException"><c>outputFormat</c> 不是有效的日期格式字符串</exception>
        /// <remarks>
        /// 1. 本方法不处理 DateTimeKind 属性<br/>
        /// 2. 解析和格式化过程均使用 <see cref="CultureInfo.InvariantCulture"/>，与系统区域设置无关
        /// </remarks>
        public static string FormatToString(string inputDateTime, string inputFormat, string outputFormat)
        {
            if (string.IsNullOrEmpty(outputFormat))
            {
                throw new ArgumentException($"输出日期格式不能为 null 或空，实际值：{(outputFormat == null ? "null" : "\"\"")}", nameof(outputFormat));
            }

            // 提前验证输出格式的有效性，避免解析成功后才发现输出格式无效
            try
            {
                _ = DateTime.MinValue.ToString(outputFormat, CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                throw new FormatException($"输出日期格式 '{outputFormat}' 不是有效的日期格式字符串", e);
            }

            var parsedDateTime = FormatToDateTime(inputDateTime, inputFormat);
            return FormatToString(parsedDateTime, outputFormat);
        }

        /// <summary>
        /// 将 UTC 基准的毫秒级 Unix 时间戳转换为指定格式的日期字符串，支持自定义 DateTime 的时区类型
        /// </summary>
        /// <param name="timestamp">基于 UTC 的 Unix 时间戳</param>
        /// <param name="format">目标日期格式字符串</param>
        /// <returns>格式化后的日期字符串</returns>
        /// <exception cref="ArgumentOutOfRangeException">timestamp 小于 -62_135_596_800_000L 或者大于 253_402_300_799_999L</exception>
        public static string FormatToString(long timestamp, string format)
        {
            const long minUnixTimeMilliseconds = -62_135_596_800_000L;
            const long maxUnixTimeMilliseconds = 253_402_300_799_999L;

            if (timestamp < minUnixTimeMilliseconds || timestamp > maxUnixTimeMilliseconds)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(timestamp),
                    actualValue: timestamp,
                    message: $"毫秒级Unix时间戳必须介于 {minUnixTimeMilliseconds} 和 {maxUnixTimeMilliseconds} 之间（对应UTC日期 0001-01-01 00:00:00 至 9999-12-31 23:59:59），实际传入值：{timestamp}");
            }

            var initDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var dateTime = DateTime.SpecifyKind(initDateTime.AddMilliseconds(timestamp), DateTimeKind.Utc);

            return FormatToString(dateTime, format);
        }

        /// <summary>
        /// 获取当前 UTC 时间的 Unix 毫秒时间戳
        /// </summary>
        /// <returns>自 1970-01-01 00:00:00 UTC 起的毫秒数</returns>
        public static long GetTimestampOfNow()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// 将指定格式的日期字符串解析为 Unix 毫秒时间戳（假设输入时间为 UTC）
        /// </summary>
        /// <param name="s">要解析的日期字符串</param>
        /// <param name="formats">允许的日期时间格式数组</param>
        /// <returns>自 1970-01-01 00:00:00 UTC 起经过的毫秒数</returns>
        /// <exception cref="ArgumentException"><c>s</c> 为 null 或空字符串</exception>
        /// <exception cref="ArgumentException"><c>formats</c> 为 null 或空数组</exception>
        /// <exception cref="ArgumentException"><c>formats</c> 所有元素均为 null 或空字符串</exception>
        /// <exception cref="FormatException">字符串 <c>s</c> 无法按照 <c>formats</c> 中的任一格式解析为有效的日期</exception>
        /// <remarks>本方法会将解析后的 DateTime 强制标记为 DateTimeKind.Utc</remarks>
        public static long GetTimestampOfString(string s, params string[] formats)
        {
            var formatToDateTime = FormatToDateTime(s, formats);
            var utcDateTime = DateTime.SpecifyKind(formatToDateTime, DateTimeKind.Utc);
            return new DateTimeOffset(utcDateTime).ToUnixTimeMilliseconds();
        }
    }
}
