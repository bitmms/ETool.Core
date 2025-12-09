namespace ETool.Core.Util
{
    /// <summary>
    /// 校验工具类
    /// </summary>
    public static class ValidatorUtil
    {
        /// <summary>
        /// 校验指定字符串是否符合手机号码的格式规范
        /// </summary>
        /// <param name="s">待校验的字符串</param>
        /// <returns>如果字符串符合手机号码的格式规范返回 true，否则返回 false</returns>
        public static bool IsValidPhoneNumber(string s)
        {
            if (StringUtil.IsNullOrEmpty(s))
            {
                return false;
            }

            if (s.Length != 11)
            {
                return false;
            }

            // 手机号码第 1 位：必须是数字 1
            if (s[0] != '1')
            {
                return false;
            }

            // 手机号码第 2 位：必须是 3-9 的数字
            if (s[1] < '3' || s[1] > '9')
            {
                return false;
            }

            // 手机号码后 9 位：必须是 0-9 的数字
            for (int i = 2; i < 11; i++)
            {
                if (!CharUtil.IsDigit(s[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
