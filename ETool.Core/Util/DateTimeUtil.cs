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
        /// 将日期按照指定格式转换成字符串
        /// </summary>
        /// <param name="datetime">要格式化日期</param>
        /// <param name="format">日期格式字符串</param>
        /// <returns>格式化后的日期字符串</returns>
        /// <remarks>
        /// 1. 本方法根据 datetime 内部数值直接格式化，不涉及任何时区的处理<br/>
        /// 2. 输出结果仅反映 datetime 的字面值，与其 DateTimeKind 属性无关
        /// </remarks>
        public static string FormatToString(DateTime datetime, string format)
        {
            return datetime.ToString(format, CultureInfo.InvariantCulture);
        }

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
        /// <remarks>本方法不处理 DateTimeKind</remarks>
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
    }
}
