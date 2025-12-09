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
    }
}
