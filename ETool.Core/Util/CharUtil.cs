namespace ETool.Core.Util
{
    /// <summary>
    /// 字符工具类
    /// </summary>
    public static class CharUtil
    {
        /// <summary>
        /// 判断入参 <c>c</c> 是否为数字（0-9）
        /// </summary>
        /// <param name="c">待判断的字符</param>
        /// <returns>若 <c>c</c> 为数字返回 <c>true</c>，否则返回 <c>false</c></returns>
        public static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        /// <summary>
        /// 判断入参 <c>c</c> 是否为大写英文字符（A-Z）
        /// </summary>
        /// <param name="c">待判断的字符</param>
        /// <returns>若 <c>c</c> 为大写英文字符返回 <c>true</c>，否则返回 <c>false</c></returns>
        public static bool IsUpperLetter(char c)
        {
            return c >= 'A' && c <= 'Z';
        }

        /// <summary>
        /// 判断入参 <c>c</c> 是否为小写英文字符（a-z）
        /// </summary>
        /// <param name="c">待判断的字符</param>
        /// <returns>若 <c>c</c> 为小写英文字符返回 <c>true</c>，否则返回 <c>false</c></returns>
        public static bool IsLowerLetter(char c)
        {
            return c >= 'a' && c <= 'z';
        }
    }
}
