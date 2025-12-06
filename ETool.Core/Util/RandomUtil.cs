using System;
using System.Threading;

namespace ETool.Core.Util
{
    /// <summary>
    /// 随机生成工具类
    /// </summary>
    public static class RandomUtil
    {
        /// <summary>
        /// 每一个线程本地存储的 Random 实例【保证多线程环境下随机数生成的线程安全与随机性】
        /// </summary>
        private static readonly ThreadLocal<Random> RandomThreadLocal = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

        /// <summary>
        /// 生成指定区间内的随机整数
        /// </summary>
        /// <param name="minValue">随机数的最小值（包含）</param>
        /// <param name="maxValue">随机数的最大值（包含）</param>
        /// <returns>介于 <c>minValue</c> 和 <c>maxValue</c> 之间的随机整数</returns>
        public static int GetRandomInt(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                (minValue, maxValue) = (maxValue, minValue);
            }

            return RandomThreadLocal.Value.Next(minValue, maxValue + 1);
        }

        /// <summary>
        /// 生成随机布尔值
        /// </summary>
        /// <returns>随机布尔值</returns>
        public static bool GetRandomBoolean()
        {
            return GetRandomInt(0, 1) == 0;
        }

        /// <summary>
        /// 生成随机数字字符
        /// </summary>
        /// <returns>随机数字字符</returns>
        public static char GetRandomDigitChar()
        {
            char[] defaultChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return defaultChars[GetRandomInt(0, 9)];
        }

        /// <summary>
        /// 生成指定长度范围的随机字符串
        /// </summary>
        /// <param name="minLength">字符串的最小长度（包含）</param>
        /// <param name="maxLength">字符串的最大长度（包含）</param>
        /// <returns>长度介于 <c>minValue</c> 和 <c>maxValue</c> 之间的随机字符串</returns>
        public static string GetRandomString(int minLength, int maxLength)
        {
            // 负数自动修正为 0
            minLength = Math.Max(minLength, 0);
            maxLength = Math.Max(maxLength, 0);

            // 自动修正参数顺序
            if (minLength > maxLength)
            {
                (minLength, maxLength) = (maxLength, minLength);
            }

            // 均为 0 时返回空字符串
            if (maxLength == 0 && minLength == 0)
            {
                return "";
            }

            // 生成随机字符串
            const string defaultCharList = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ`~!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";
            int len = RandomThreadLocal.Value.Next(minLength, maxLength + 1);
            char[] resultChars = new char[len];
            for (int i = 0; i < len; i++)
            {
                resultChars[i] = defaultCharList[RandomThreadLocal.Value.Next(0, defaultCharList.Length)];
            }

            return new string(resultChars);
        }
    }
}
