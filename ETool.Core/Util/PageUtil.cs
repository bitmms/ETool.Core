using System;

namespace ETool.Core.Util
{
    /// <summary>
    /// 分页工具类
    /// </summary>
    public static class PageUtil
    {
        /// <summary>
        /// 根据总数计算总页数
        /// </summary>
        /// <param name="totalCount">元素的总数量</param>
        /// <param name="pageSize">每页元素的数量</param>
        /// <returns>总页数</returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>totalCount</c> 小于 0</exception>
        /// <exception cref="ArgumentOutOfRangeException"><c>pageSize</c> 小于等于 0</exception>
        /// <example>
        /// <code>
        /// GetTotalPages(0, 10)   → 0
        /// GetTotalPages(1, 10)   → 1
        /// GetTotalPages(10, 10)  → 1
        /// GetTotalPages(11, 10)  → 2
        /// GetTotalPages(97, 10)  → 10
        /// </code>
        /// </example>
        public static int GetTotalPages(int totalCount, int pageSize)
        {
            if (totalCount < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(totalCount),
                    totalCount,
                    $"元素总数 '{nameof(totalCount)}' 必须大于等于 0，实际值：{totalCount}");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(pageSize),
                    pageSize,
                    $"每页大小 '{nameof(pageSize)}' 必须大于 0，实际值：{pageSize}");
            }

            return totalCount == 0 ? 0 : (totalCount - 1) / pageSize + 1;
        }
    }
}
