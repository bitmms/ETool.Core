namespace ETool.Core.Util
{
    /// <summary>
    /// 字符工具类
    /// </summary>
    public static class CharUtil
    {
        /// <summary>
        /// 判断指定字符是否为数字
        /// </summary>
        /// <param name="c">待判断的字符</param>
        /// <returns>如果字符为数字返回 true，否则返回 false</returns>
        public static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        /// <summary>
        /// 判断指定字符是否为英文字符
        /// </summary>
        /// <param name="c">待判断的字符</param>
        /// <returns>如果字符为英文字符返回 true，否则返回 false</returns>
        public static bool IsLetter(char c)
        {
            return c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z';
        }

        /// <summary>
        /// 判断指定字符是否为大写英文字符
        /// </summary>
        /// <param name="c">待判断的字符</param>
        /// <returns>如果字符为大写英文字符返回 true，否则返回 false</returns>
        public static bool IsUpperLetter(char c)
        {
            return c >= 'A' && c <= 'Z';
        }
    }
}
