namespace ETool.Core.Util
{
    /// <summary>
    /// 整数工具类
    /// </summary>
    public static class NumberUtil
    {
        /// <summary>
        /// 比较 <c>x1</c> 和 <c>x2</c>，当 <c>x1 &lt; x2</c> 时交换二者的值
        /// </summary>
        /// <param name="x1">第一个整数（ref 类型，最终存储较大值）</param>
        /// <param name="x2">第二个整数（ref 类型，最终存储较小值）</param>
        public static void SwapIfFirstSmaller(ref int x1, ref int x2)
        {
            if (x1 < x2)
            {
                CommonUtil.Swap(ref x1, ref x2);
            }
        }

        /// <summary>
        /// 比较 <c>x1</c> 和 <c>x2</c>，当 <c>x1 &gt; x2</c> 时交换二者的值
        /// </summary>
        /// <param name="x1">第一个整数（ref 类型，最终存储较小值）</param>
        /// <param name="x2">第二个整数（ref 类型，最终存储较大值）</param>
        public static void SwapIfFirstLarger(ref int x1, ref int x2)
        {
            if (x1 > x2)
            {
                CommonUtil.Swap(ref x1, ref x2);
            }
        }
    }
}
