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
    }
}
