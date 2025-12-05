namespace ETool.Core.Util
{
    /// <summary>
    ///  数据脱敏工具类
    /// </summary>
    public static class MaskUtil
    {
        /// <summary>
        /// 手机号脱敏处理：保留前3位和后4位，中间4位替换为指定掩码字符
        /// </summary>
        /// <param name="phoneNumber">待脱敏的手机号字符串</param>
        /// <param name="maskChar">用于替换中间4位的掩码填充字符</param>
        /// <returns>合法手机号返回脱敏字符串；null 返回空字符串；其他非法手机号返回原字符串</returns>
        public static string MaskPhoneNumber(string phoneNumber, char maskChar = '*')
        {
            if (StrUtil.IsNull(phoneNumber))
            {
                return "";
            }

            if (ValidatorUtil.IsValidPhoneNumber(phoneNumber))
            {
                return StrUtil.ReplaceRangeWithChar(phoneNumber, 3, 4, maskChar);
            }

            return phoneNumber;
        }
    }
}
