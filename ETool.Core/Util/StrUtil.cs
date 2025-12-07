using System;
using System.Collections.Generic;
using System.Text;

namespace ETool.Core.Util
{
    /// <summary>
    /// 字符串工具类
    /// </summary>
    public static class StrUtil
    {
        /// <summary>
        /// 判断入参 <c>s</c> 是否为 <c>null</c>
        /// </summary>
        /// <param name="s">待判断的字符串</param>
        /// <returns>若 <c>s</c> 为 <c>null</c> 返回 <c>true</c>，否则返回 <c>false</c></returns>
        public static bool IsNull(string s)
        {
            return s == null;
        }

        /// <summary>
        /// 判断入参 <c>s</c> 是否为 <c>""</c>
        /// </summary>
        /// <param name="s">待判断的字符串</param>
        /// <returns>若 <c>s</c> 为 <c>""</c> 返回 <c>true</c>，否则返回 <c>false</c></returns>
        public static bool IsEmpty(string s)
        {
            return s != null && s.Length == 0;
        }

        /// <summary>
        /// 判断入参 <c>s</c> 是否全为空白字符
        /// </summary>
        /// <param name="s">待判断的字符串</param>
        /// <returns>若 <c>s</c> 全为空白字符返回 <c>true</c>，否则返回 <c>false</c></returns>
        public static bool IsAllWhiteSpace(string s)
        {
            return !IsNull(s) && !IsEmpty(s) && s.Trim().Length == 0;
        }

        /// <summary>
        /// 将字符串中的小写英文字符转大写
        /// </summary>
        /// <param name="str">待转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ToUpperLetter(string str)
        {
            if (IsNull(str) || IsEmpty(str))
            {
                return "";
            }

            int len = str.Length;
            char[] chars = new char[len];
            for (int i = 0; i < len; i++)
            {
                if (CharUtil.IsLowerLetter(str[i]))
                {
                    chars[i] = CharUtil.ToUpperLetter(str[i]);
                }
                else
                {
                    chars[i] = str[i];
                }
            }

            return new string(chars);
        }

        /// <summary>
        /// 将字符串中的大写英文字符转小写
        /// </summary>
        /// <param name="str">待转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ToLowerLetter(string str)
        {
            if (IsNull(str) || IsEmpty(str))
            {
                return "";
            }

            int len = str.Length;
            char[] chars = new char[len];
            for (int i = 0; i < len; i++)
            {
                if (CharUtil.IsUpperLetter(str[i]))
                {
                    chars[i] = CharUtil.ToLowerLetter(str[i]);
                }
                else
                {
                    chars[i] = str[i];
                }
            }

            return new string(chars);
        }

        /// <summary>
        /// 将字符串指定区间的字符替换为目标字符
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="startIndex">替换起始索引</param>
        /// <param name="count">替换字符数量</param>
        /// <param name="targetChar">用于替换的目标字符</param>
        /// <returns>替换后的新字符串</returns>
        public static string ReplaceRangeWithChar(string sourceString, int startIndex, int count, char targetChar)
        {
            if (IsNull(sourceString) || IsEmpty(sourceString))
            {
                return "";
            }

            int length = sourceString.Length;
            startIndex = Math.Max(startIndex, 0);
            count = Math.Min(Math.Max(count, 0), length - startIndex); // 确保 count 非负且不超过剩余长度

            if (startIndex >= length || count == 0)
            {
                return sourceString;
            }

            char[] resultChars = sourceString.ToCharArray();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                resultChars[i] = targetChar;
            }

            return new string(resultChars);
        }

        /// <summary>
        /// 字符串序列转字符串
        /// </summary>
        /// <param name="stringItems">待拼接的字符串序列</param>
        /// <param name="separator">分隔符</param>
        /// <param name="skipNull">是否跳过 null 元素</param>
        /// <param name="nullReplacement">当 null 元素参与字符串拼接时，null 元素的替换字符串</param>
        /// <returns>拼接后的字符串</returns>
        public static string JoinStrings(IEnumerable<string> stringItems, char separator, bool skipNull = true, string nullReplacement = "null")
        {
            if (stringItems == null)
            {
                return "";
            }

            if (!skipNull && IsNull(nullReplacement))
            {
                nullReplacement = "null";
            }

            bool first = true;
            StringBuilder sb = new StringBuilder();
            foreach (string item in stringItems)
            {
                if (IsNull(item) && skipNull)
                {
                    continue;
                }

                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(separator);
                }

                sb.Append(IsNull(item) ? nullReplacement : item);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 字符串重复指定次数
        /// </summary>
        /// <param name="str">待重复的字符串</param>
        /// <param name="count">重复的次数</param>
        /// <param name="separator">分隔符</param>
        /// <returns>拼接后的字符串</returns>
        public static string RepeatString(string str, int count, string separator = "")
        {
            if (IsNull(str) || IsEmpty(str))
            {
                return "";
            }

            if (count <= 0)
            {
                return "";
            }

            if (count == 1)
            {
                return str;
            }

            if (IsNull(separator))
            {
                separator = "";
            }

            // 判断整数溢出
            long totalLength = str.Length + (long)(count - 1) * (separator.Length + str.Length);
            if (totalLength > int.MaxValue)
            {
                return str;
            }

            StringBuilder sb = new StringBuilder((int)totalLength);

            sb.Append(str);
            for (int i = 1; i < count; i++)
            {
                sb.Append(separator).Append(str);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 字符重复指定次数
        /// </summary>
        /// <param name="c">待重复的字符</param>
        /// <param name="count">重复的次数</param>
        /// <param name="separator">分隔符</param>
        /// <returns>拼接后的字符串</returns>
        public static string RepeatChar(char c, int count, string separator = "")
        {
            if (count <= 0)
            {
                return "";
            }

            if (count == 1)
            {
                return $"{c}";
            }

            if (IsNull(separator) || IsEmpty(separator))
            {
                return new string(c, count);
            }

            // 判断整数溢出
            long totalLength = 1 + (long)(count - 1) * (separator.Length + 1);
            if (totalLength > int.MaxValue)
            {
                return $"{c}";
            }

            StringBuilder sb = new StringBuilder((int)totalLength);

            sb.Append(c);
            for (int i = 1; i < count; i++)
            {
                sb.Append(separator).Append(c);
            }

            return sb.ToString();
        }
    }
}
