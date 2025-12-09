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
        /// 获取一个线程安全的 Random 实例
        /// </summary>
        /// <returns>线程安全的 Random 实例</returns>
        public static Random GetRandom()
        {
            return RandomThreadLocal.Value;
        }

        /// <summary>
        /// 获取一个指定区间内的随机整数
        /// </summary>
        /// <param name="minValue">随机数的最小值（包含）</param>
        /// <param name="maxValue">随机数的最大值（包含）</param>
        /// <returns>介于 <c>minValue</c> 和 <c>maxValue</c> 之间的随机整数</returns>
        public static int GetRandomInt(int minValue, int maxValue)
        {
            NumberUtil.SwapIfFirstLarger(ref minValue, ref maxValue);

            return GetRandom().Next(minValue, maxValue + 1);
        }

        /// <summary>
        /// 获取一个随机的布尔值
        /// </summary>
        /// <returns>随机的布尔值</returns>
        public static bool GetRandomBool()
        {
            return GetRandomInt(0, 1) == 0;
        }

        /// <summary>
        /// 获取一个随机的数字字符
        /// </summary>
        /// <param name="minValue">最小的随机字符对应的数值（包含），默认值为 0</param>
        /// <param name="maxValue">最大的随机字符对应的数值（包含），默认值为 9</param>
        /// <returns>介于 <c>minValue</c> 和 <c>maxValue</c> 之间的随机数字字符</returns>
        public static char GetRandomDigitChar(int minValue = 0, int maxValue = 9)
        {
            // 负数自动修正为 0
            minValue = Math.Max(minValue, 0);
            maxValue = Math.Max(maxValue, 0);

            // 自动修正参数顺序
            NumberUtil.SwapIfFirstLarger(ref minValue, ref maxValue);

            char[] defaultChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            // 超出有效范围时：返回 0-9 的随机字符
            if (minValue > 9)
            {
                return defaultChars[GetRandomInt(0, 9)];
            }

            return defaultChars[GetRandomInt(minValue, maxValue)];
        }
    }
}
