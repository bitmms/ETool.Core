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
    }
}
