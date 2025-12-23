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

        /// <summary>
        /// 计算分页的开始索引（包含）
        /// </summary>
        /// <param name="pageNumber">当前页码</param>
        /// <param name="pageSize">每页包含的元素数量</param>
        /// <returns>分页的开始索引（包含）</returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>pageNumber</c> 小于等于 0</exception>
        /// <exception cref="ArgumentOutOfRangeException"><c>pageSize</c> 小于等于 0</exception>
        /// <exception cref="OverflowException">计算得出的开始索引超出了 int 的范围</exception>
        /// <example>
        /// <code>
        /// GetStartIndex(1, 10) → 0
        /// GetStartIndex(2, 10) → 10
        /// GetStartIndex(3, 5)  → 10
        /// </code>
        /// </example>
        public static int GetStartIndex(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(pageNumber),
                    pageNumber,
                    $"当前页码 '{nameof(pageNumber)}' 必须大于 0，实际值：{pageNumber}");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(pageSize),
                    pageSize,
                    $"每页大小 '{nameof(pageSize)}' 必须大于 0，实际值：{pageSize}");
            }

            var startIndexLong = (long)(pageNumber - 1) * pageSize;
            if (startIndexLong > int.MaxValue)
            {
                throw new OverflowException($"分页开始索引溢出超出 int 范围：(pageNumber - 1) * pageSize = ({pageNumber} - 1) * {pageSize} = {startIndexLong} > int.MaxValue = {int.MaxValue}");
            }

            return (int)startIndexLong;
        }

        /// <summary>
        /// 计算分页的结束索引（不包含）
        /// </summary>
        /// <param name="startIndex">分页的开始索引（包含）</param>
        /// <param name="pageSize">每页包含的元素数量</param>
        /// <returns>分页的结束索引（不包含）</returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>startIndex</c> 小于 0</exception>
        /// <exception cref="ArgumentOutOfRangeException"><c>pageSize</c> 小于等于 0</exception>
        /// <exception cref="OverflowException">计算得出的结束索引超出了 int 的范围</exception>
        /// <example>
        /// <code>
        /// GetEndIndexExclusiveByStartIndex(11, 10) → 21
        /// GetEndIndexExclusiveByStartIndex(18, 10) → 28
        /// GetEndIndexExclusiveByStartIndex(33, 15) → 48
        /// </code>
        /// </example>
        public static int GetEndIndexExclusiveByStartIndex(int startIndex, int pageSize)
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(startIndex),
                    startIndex,
                    $"分页开始索引 '{nameof(startIndex)}' 必须大于等于 0，实际值：{startIndex}");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(pageSize),
                    pageSize,
                    $"每页大小 '{nameof(pageSize)}' 必须大于 0，实际值：{pageSize}");
            }

            var endIndexLong = (long)startIndex + pageSize;
            if (endIndexLong > int.MaxValue)
            {
                throw new OverflowException($"分页结束索引溢出超出 int 范围：startIndex + pageSize = {startIndex} + {pageSize} = {endIndexLong} > int.MaxValue = {int.MaxValue}");
            }

            return (int)endIndexLong;
        }
    }
}
