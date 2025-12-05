namespace ETool.Core.Util
{
    /// <summary>
    /// 数据校验工具类
    /// </summary>
    public static class ValidatorUtil
    {
        /// <summary>
        /// 校验入参 <c>str</c> 是否符合中国大陆 11 位手机号码格式规范
        /// </summary>
        /// <param name="str">待校验的字符串</param>
        /// <returns>符合格式返回 <c>true</c>，否则返回 <c>false</c></returns>
        public static bool IsValidPhoneNumber(string str)
        {
            if (StrUtil.IsNull(str) || StrUtil.IsEmpty(str) || StrUtil.IsAllWhiteSpace(str))
            {
                return false;
            }

            if (str.Length != 11)
            {
                return false;
            }

            // 手机号码第 1 位：必须是数字 1
            if (str[0] != '1')
            {
                return false;
            }

            // 手机号码第 2 位：必须是 3-9 的数字
            if (str[1] < '3' || str[1] > '9')
            {
                return false;
            }

            // 手机号码后 9 位：必须是 0-9 的数字
            for (int i = 2; i < 11; i++)
            {
                if (!CharUtil.IsDigit(str[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 校验入参 <c>str</c> 是否为正整数
        /// </summary>
        /// <param name="str">待校验的字符串</param>
        /// <returns>符合格式返回 <c>true</c>，否则返回 <c>false</c></returns>
        public static bool IsValidPositiveNumber(string str)
        {
            if (StrUtil.IsNull(str) || StrUtil.IsEmpty(str) || StrUtil.IsAllWhiteSpace(str))
            {
                return false;
            }

            // 不允许前导零的存在
            if (str[0] == '0')
            {
                return false;
            }

            // 逐字符检查是否为数字
            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                if (!CharUtil.IsDigit(str[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
