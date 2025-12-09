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
    }
}
