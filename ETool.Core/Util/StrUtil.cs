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
    }
}
