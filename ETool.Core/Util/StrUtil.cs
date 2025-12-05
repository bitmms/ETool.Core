using System;

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
    }
}
