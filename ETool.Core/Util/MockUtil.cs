using System.Collections.Generic;

namespace ETool.Core.Util
{
    /// <summary>
    /// 模拟数据工具类
    /// </summary>
    public static class MockUtil
    {
        /// <summary>
        /// 生成随机的 11 位手机号码
        /// </summary>
        /// <returns>随机生成的 11 位手机号码</returns>
        public static string GetRandomPhoneNumber()
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

        /// <summary>
        /// 批量生成随机的 11 位手机号码
        /// </summary>
        /// <returns>随机生成的 11 位手机号码列表</returns>
        public static List<string> GetRandomPhoneNumberList(int count)
        {
            if (count <= 0)
            {
                return new List<string>();
            }

            List<string> list = new List<string>(count);
            for (int i = 1; i <= count; i++)
            {
                list.Add(GetRandomPhoneNumber());
            }

            return list;
        }
    }
}
