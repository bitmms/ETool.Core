using System;

namespace ETool.Core.Util
{
    /// <summary>
    /// 字符串工具类
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// 判断指定字符串是否为 null
        /// </summary>
        /// <param name="s">待判断的字符串</param>
        /// <returns>如果字符串为 null 返回 true，否则返回 false</returns>
        public static bool IsNull(string s)
        {
            return s == null;
        }

        /// <summary>
        /// 判断指定字符串是否不为 null
        /// </summary>
        /// <param name="s">待判断的字符串</param>
        /// <returns>如果字符串不为 null 返回 true，否则返回 false</returns>
        public static bool IsNotNull(string s)
        {
            return s != null;
        }

        /// <summary>
        /// 判断指定字符串是否为空
        /// </summary>
        /// <param name="s">待判断的字符串</param>
        /// <returns>如果字符串为空返回 true，否则返回 false</returns>
        public static bool IsEmpty(string s)
        {
            return s == string.Empty;
        }

        /// <summary>
        /// 判断指定字符串是否不为空
        /// </summary>
        /// <param name="s">待判断的字符串</param>
        /// <returns>如果字符串不为空返回 true，否则返回 false</returns>
        public static bool IsNotEmpty(string s)
        {
            return s != string.Empty;
        }

        /// <summary>
        /// 判断指定字符串是否为 null 或为空
        /// </summary>
        /// <param name="s">待判断的字符串</param>
        /// <returns>如果字符串为 null 或为空返回 true，否则返回 false</returns>
        public static bool IsNullOrEmpty(string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// 将字符串中的小写英文字符转大写
        /// </summary>
        /// <param name="s">待转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ToUpperLetter(string s)
        {
            if (IsNullOrEmpty(s))
            {
                return "";
            }

            int len = s.Length;
            char[] resultChars = new char[len];
            for (int i = 0; i < len; i++)
            {
                if (CharUtil.IsLowerLetter(s[i]))
                {
                    resultChars[i] = CharUtil.ToUpperLetter(s[i]);
                }
                else
                {
                    resultChars[i] = s[i];
                }
            }

            return new string(resultChars);
        }

        /// <summary>
        /// 将字符串中的大写英文字符转小写
        /// </summary>
        /// <param name="s">待转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ToLowerLetter(string s)
        {
            if (IsNullOrEmpty(s))
            {
                return "";
            }

            int len = s.Length;
            char[] chars = new char[len];
            for (int i = 0; i < len; i++)
            {
                if (CharUtil.IsUpperLetter(s[i]))
                {
                    chars[i] = CharUtil.ToLowerLetter(s[i]);
                }
                else
                {
                    chars[i] = s[i];
                }
            }

            return new string(chars);
        }

        /// <summary>
        /// 将指定字符重复指定次数
        /// </summary>
        /// <param name="c">待重复的字符</param>
        /// <param name="count">重复次数</param>
        /// <param name="sep">分隔符</param>
        /// <returns>重复拼接后的字符串</returns>
        public static string Repeat(char c, int count, char sep = ' ')
        {
            if (count <= 0)
            {
                return "";
            }

            if (count == 1)
            {
                return c.ToString();
            }

            long totalLength = 2L * count - 1;
            if (totalLength > int.MaxValue)
            {
                return "";
            }

            char[] resultChars = new char[totalLength];

            int nextIndex = 0;
            resultChars[nextIndex] = c;
            nextIndex += 1;
            for (int i = 1; i < count; i++)
            {
                resultChars[nextIndex] = sep;
                nextIndex += 1;

                resultChars[nextIndex] = c;
                nextIndex += 1;
            }

            return new string(resultChars);
        }

        /// <summary>
        /// 将指定字符重复指定次数
        /// </summary>
        /// <param name="c">待重复的字符</param>
        /// <param name="count">重复次数</param>
        /// <param name="sep">分隔符</param>
        /// <returns>重复拼接后的字符串</returns>
        public static string Repeat(char c, int count, string sep = " ")
        {
            if (count <= 0)
            {
                return "";
            }

            if (count == 1)
            {
                return c.ToString();
            }

            if (IsNull(sep))
            {
                sep = "";
            }

            if (IsEmpty(sep))
            {
                return new string(c, count);
            }

            long totalLength = (long)(1 + sep.Length) * count - sep.Length;
            if (totalLength > int.MaxValue)
            {
                return "";
            }

            char[] resultChars = new char[totalLength];

            int nextIndex = 0;
            resultChars[nextIndex] = c;
            nextIndex += 1;
            for (int i = 1; i < count; i++)
            {
                sep.CopyTo(0, resultChars, nextIndex, sep.Length);
                nextIndex += sep.Length;

                resultChars[nextIndex] = c;
                nextIndex += 1;
            }

            return new string(resultChars);
        }

        /// <summary>
        /// 将指定字符串重复指定次数
        /// </summary>
        /// <param name="s">待重复的源字符串</param>
        /// <param name="count">重复次数</param>
        /// <param name="sep">分隔符</param>
        /// <returns>重复拼接后的字符串</returns>
        public static string Repeat(string s, int count, char sep = ' ')
        {
            if (IsNull(s) || count <= 0)
            {
                return "";
            }

            if (count == 1)
            {
                return s;
            }

            long totalLength = (long)(s.Length + 1) * count - 1;
            if (totalLength > int.MaxValue)
            {
                return "";
            }

            char[] resultChars = new char[totalLength];

            int nextIndex = 0;
            s.CopyTo(0, resultChars, nextIndex, s.Length);
            nextIndex += s.Length;
            for (int i = 1; i < count; i++)
            {
                resultChars[nextIndex] = sep;
                nextIndex += 1;

                s.CopyTo(0, resultChars, nextIndex, s.Length);
                nextIndex += s.Length;
            }

            return new string(resultChars);
        }

        /// <summary>
        /// 将指定字符串重复指定次数
        /// </summary>
        /// <param name="s">待重复的源字符串</param>
        /// <param name="count">重复次数</param>
        /// <param name="sep">分隔符</param>
        /// <returns>重复拼接后的字符串</returns>
        public static string Repeat(string s, int count, string sep = " ")
        {
            if (IsNull(s) || count <= 0)
            {
                return "";
            }

            if (count == 1)
            {
                return s;
            }

            if (IsNull(sep))
            {
                sep = "";
            }

            long totalLength = (long)(s.Length + sep.Length) * count - sep.Length;
            if (totalLength > int.MaxValue)
            {
                return "";
            }

            char[] resultChars = new char[totalLength];

            if (IsEmpty(sep))
            {
                // 开头部分：直接手动拷贝
                s.CopyTo(0, resultChars, 0, s.Length);

                // 记录当前已经拷贝的数量
                int n = s.Length;

                // 中间部分：倍增拷贝
                while (n < totalLength - n)
                {
                    Array.Copy(resultChars, 0, resultChars, n, n);
                    n <<= 1; // n *= 2;
                }

                // 结尾部分：直接手动拷贝
                Array.Copy(resultChars, 0, resultChars, n, totalLength - n);

                return new string(resultChars);
            }

            int nextIndex = 0;
            s.CopyTo(0, resultChars, nextIndex, s.Length);
            nextIndex += s.Length;
            for (int i = 1; i < count; i++)
            {
                sep.CopyTo(0, resultChars, nextIndex, sep.Length);
                nextIndex += sep.Length;

                s.CopyTo(0, resultChars, nextIndex, s.Length);
                nextIndex += s.Length;
            }

            return new string(resultChars);
        }
    }
}
