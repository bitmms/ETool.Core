namespace ETool.Core.Util
{
    /// <summary>
    /// 模拟数据工具类
    /// </summary>
    public static class MockUtil
    {
        #region 生成模拟的 11 位手机号码

        /// <summary>
        /// 生成模拟的 11 位手机号码
        /// </summary>
        /// <returns>模拟生成的 11 位手机号码</returns>
        public static string MockPhoneNumber()
        {
            char[] resultChars = new char[11];

            resultChars[0] = '1';
            resultChars[1] = RandomUtil.GetRandomDigitChar(3, 9);
            for (int i = 2; i < 11; i++)
            {
                resultChars[i] = RandomUtil.GetRandomDigitChar(0, 9);
            }

            return new string(resultChars);
        }

        #endregion
    }
}
