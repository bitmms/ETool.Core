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

        /// <summary>
        /// 校验入参 <c>str</c> 是否符合 QQ 号码格式规范
        /// </summary>
        /// <param name="str">待校验的字符串</param>
        /// <returns>符合格式返回 <c>true</c>，否则返回 <c>false</c></returns>
        public static bool IsValidQqNumber(string str)
        {
            if (StrUtil.IsNull(str) || StrUtil.IsEmpty(str) || StrUtil.IsAllWhiteSpace(str))
            {
                return false;
            }

            // 长度校验：必须是 5-11 位
            int len = str.Length;
            if (len < 5 || len > 11)
            {
                return false;
            }

            // 首位校验：必须是 1-9 的数字
            if (str[0] < '1' || str[0] > '9')
            {
                return false;
            }

            // 除首位的其他字符校验：必须是 0-9 的数字
            for (int i = 1; i < len; i++)
            {
                if (!CharUtil.IsDigit(str[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 校验入参 <c>str</c> 是否符合 IPv4 地址的点分十进制表示法
        /// </summary>
        /// <param name="str">待校验的字符串</param>
        /// <returns>符合格式返回 <c>true</c>，否则返回 <c>false</c></returns>
        public static bool IsValidIpv4(string str)
        {
            if (StrUtil.IsNull(str) || StrUtil.IsEmpty(str) || StrUtil.IsAllWhiteSpace(str))
            {
                return false;
            }

            // 长度超出合法范围【最短7位(0.0.0.0)，最长15位(255.255.255.255)】
            int len = str.Length;
            if (len < 7 || len > 15)
            {
                return false;
            }

            // 字符校验：仅能包含数字 0-9 和小数点
            for (int i = 0; i < len; i++)
            {
                if (!(CharUtil.IsDigit(str[i]) || str[i] == '.'))
                {
                    return false;
                }
            }

            // 片段必须为 4 段
            string[] segments = str.Split('.');
            if (segments.Length != 4)
            {
                return false;
            }

            foreach (string segment in segments)
            {
                // 失败：段为空校验
                if (StrUtil.IsEmpty(segment))
                {
                    return false;
                }

                // 失败：前导零校验
                int segLen = segment.Length;
                if (segLen > 1 && segment[0] == '0')
                {
                    return false;
                }

                // 失败：段长度校验
                if (segLen > 3)
                {
                    return false;
                }

                // 数值范围校验（0-255）
                int num = 0;
                foreach (char c in segment)
                {
                    num = num * 10 + (c - '0');
                    if (num > 255)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
