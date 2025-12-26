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
    }
}
