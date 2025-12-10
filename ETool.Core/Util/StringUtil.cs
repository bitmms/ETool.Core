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
        /// 比较两个字符串是否相等
        /// </summary>
        /// <param name="s1">第一个字符串</param>
        /// <param name="s2">第二个字符串</param>
        /// <param name="ignoreCase">是否忽略英文字符的大小写</param>
        /// <returns>如果字符串相等返回 true，否则返回 false</returns>
        public static bool Compare(string s1, string s2, bool ignoreCase = false)
        {
            if (IsNull(s1) && IsNull(s2))
            {
                return true;
            }

            if (IsNull(s1) || IsNull(s2))
            {
                return false;
            }

            if (s1.Length != s2.Length)
            {
                return false;
            }

            if (!ignoreCase)
            {
                return s1 == s2;
            }

            int len = s1.Length;
            for (int i = 0; i < len; i++)
            {
                if (CharUtil.ToUpperLetter(s1[i]) != CharUtil.ToUpperLetter(s2[i]))
                {
                    return false;
                }
            }

            return true;
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

        /// <summary>
        /// 在字符串的指定范围内查找指定字符首次出现的索引
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="c">目标字符</param>
        /// <param name="start">起始索引位置（包含）</param>
        /// <param name="count">需要检查的字符数量</param>
        /// <param name="ignoreCase">是否忽略英文字符的大小写</param>
        /// <returns>找到返回索引，否则返回 -1</returns>
        public static int IndexOf(string s, char c, int start, int count, bool ignoreCase = false)
        {
            if (IsNull(s) || IsEmpty(s))
            {
                return -1;
            }

            if (start >= s.Length || count <= 0)
            {
                return -1;
            }

            if (start < 0)
            {
                start = 0;
            }

            if (count > s.Length - start)
            {
                count = s.Length - start;
            }

            int endIndex = start + count - 1;

            if (!ignoreCase)
            {
                for (int i = start; i <= endIndex; i++)
                {
                    if (s[i] == c)
                    {
                        return i;
                    }
                }
            }
            else
            {
                char upperTargetChar = CharUtil.ToUpperLetter(c);
                for (int i = start; i <= endIndex; i++)
                {
                    if (CharUtil.ToUpperLetter(s[i]) == upperTargetChar)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 在字符串中查找指定字符首次出现的索引
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="c">目标字符</param>
        /// <param name="ignoreCase">是否忽略英文字符的大小写</param>
        /// <returns>找到返回索引，否则返回 -1</returns>
        public static int IndexOf(string s, char c, bool ignoreCase = false)
        {
            if (IsNull(s))
            {
                return -1;
            }

            return IndexOf(s, c, 0, s.Length, ignoreCase);
        }

        /// <summary>
        /// 在字符串的指定范围内查找指定子串首次出现的索引 TODO: 使用 KMP 算法优化
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="targetString">目标子串</param>
        /// <param name="start">起始索引位置（包含）</param>
        /// <param name="count">需要检查的字符数量</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns>找到返回索引，否则返回 -1</returns>
        public static int IndexOf(string sourceString, string targetString, int start, int count, bool ignoreCase = false)
        {
            if (IsNull(sourceString) || IsNull(targetString))
            {
                return -1;
            }

            if (start >= sourceString.Length || count <= 0)
            {
                return -1;
            }

            if (start < 0)
            {
                start = 0;
            }

            if (IsEmpty(targetString))
            {
                return start;
            }

            if (count > sourceString.Length - start)
            {
                count = sourceString.Length - start;
            }

            if (count < targetString.Length)
            {
                return -1;
            }

            // 外层循环：尝试每一个可能的起始位置
            int lastStart = start + (count - 1) - (targetString.Length - 1);
            for (int i = start; i <= lastStart; i++)
            {
                bool match = true;

                // 内层循环：逐字符比较
                for (int j = 0; j < targetString.Length; j++)
                {
                    char sourceChar = sourceString[i + j];
                    char targetChar = targetString[j];

                    if (ignoreCase)
                    {
                        sourceChar = CharUtil.ToUpperLetter(sourceChar);
                        targetChar = CharUtil.ToUpperLetter(targetChar);
                    }

                    if (sourceChar != targetChar)
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    return i;
                }
            }


            return -1;
        }
    }
}
