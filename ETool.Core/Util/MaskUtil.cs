namespace ETool.Core.Util
{
    /// <summary>
    /// 数据脱敏工具类
    /// </summary>
    public static class MaskUtil
    {
        /// <summary>
        /// 手机号码脱敏处理：保留前3位和后4位，中间4位替换为指定掩码字符
        /// </summary>
        /// <param name="phoneNumber">待脱敏的手机号码字符串</param>
        /// <param name="maskChar">用于替换的填充字符</param>
        /// <returns>脱敏后的字符串</returns>
        public static string MaskPhoneNumber(string phoneNumber, char maskChar = '*')
        {
            if (StringUtil.IsNull(phoneNumber))
            {
                return "";
            }

            if (ValidatorUtil.IsValidPhoneNumber(phoneNumber))
            {
                return StringUtil.ReplaceRangeWithChar(phoneNumber, 3, 4, maskChar);
            }

            return phoneNumber;
        }

        /// <summary>
        /// 身份证号码脱敏处理：保留前3位和后3位，中间部分替换为指定掩码字符【兼容15、18位身份证号码】
        /// </summary>
        /// <param name="idCard">待脱敏的身份证号码字符串</param>
        /// <param name="maskChar">用于替换的填充字符</param>
        /// <returns>脱敏后的字符串</returns>
        public static string MaskIdCard(string idCard, char maskChar = '*')
        {
            if (StringUtil.IsNull(idCard))
            {
                return "";
            }

            if (!IdCardUtil.IsValidChinaIdCard(idCard))
            {
                return idCard;
            }

            if (idCard.Length == 18)
            {
                return StringUtil.ReplaceRangeWithChar(idCard, 3, 12, maskChar);
            }

            return StringUtil.ReplaceRangeWithChar(idCard, 3, 9, maskChar);
        }
    }
}
