namespace ETool.Core.Util
{
    /// <summary>
    /// 通用工具类
    /// </summary>
    public static class CommonUtil
    {
        /// <summary>
        /// 交换两个任意同类型变量的值
        /// </summary>
        /// <param name="param1">第一个变量（ref）</param>
        /// <param name="param2">第二个变量（ref）</param>
        /// <typeparam name="T">变量的类型</typeparam>
        public static void Swap<T>(ref T param1, ref T param2)
        {
            (param1, param2) = (param2, param1);
        }
    }
}
