using System;
using System.Text;

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
                (x1, x2) = (x2, x1);
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
                (x1, x2) = (x2, x1);
            }
        }

        /// <summary>
        /// 比较两个正整数的大小【私有方法：可以确保 n1，n2均为正整数且不包含前导0】
        /// </summary>
        /// <param name="n1">第一个正整数</param>
        /// <param name="n2">第二个正整数</param>
        /// <returns>n1 大于 n2 返回 1；n1 小于 n2 返回 -1；否则返回 0</returns>
        private static int Compare(string n1, string n2)
        {
            if (n1.Length < n2.Length) return -1;
            if (n1.Length > n2.Length) return 1;
            for (int i = 0; i < n1.Length; i++)
            {
                if (n1[i] > n2[i]) return 1;
                if (n1[i] < n2[i]) return -1;
            }

            return 0;
        }

        /// <summary>
        /// 将两个正整数相加【私有方法：可以确保 n1，n2均为正整数且不包含前导0】
        /// </summary>
        /// <param name="n1">第一个正整数</param>
        /// <param name="n2">第二个正整数</param>
        /// <returns>正整数相加的和</returns>
        private static string AddPositive(string n1, string n2)
        {
            int[] arr1 = new int[n1.Length];
            int[] arr2 = new int[n2.Length];
            for (int i = n1.Length - 1, j = 0; i >= 0; i--, j++)
            {
                arr1[j] = n1[i] - '0';
            }

            for (int i = n2.Length - 1, j = 0; i >= 0; i--, j++)
            {
                arr2[j] = n2[i] - '0';
            }

            StringBuilder resultSb = new StringBuilder(Math.Max(n1.Length, n2.Length) + 1);

            for (int i = 0, carry = 0; i < arr1.Length || i < arr2.Length || carry != 0; i++)
            {
                if (i < arr1.Length) carry += arr1[i];
                if (i < arr2.Length) carry += arr2[i];
                resultSb.Append(carry % 10);
                carry /= 10;
            }

            char[] resultChars = resultSb.ToString().ToCharArray();
            Array.Reverse(resultChars);

            return new string(resultChars);
        }

        /// <summary>
        /// 将两个正整数相减【私有方法：可以确保 n1，n2均为正整数且不包含前导0，并且 n1 >= n2】
        /// </summary>
        /// <param name="n1">第一个正整数</param>
        /// <param name="n2">第二个正整数</param>
        /// <returns>n1 减 n2 的差值</returns>
        private static string SubPositive(string n1, string n2)
        {
            int[] arr1 = new int[n1.Length];
            int[] arr2 = new int[n2.Length];
            for (int i = n1.Length - 1, j = 0; i >= 0; i--, j++)
            {
                arr1[j] = n1[i] - '0';
            }

            for (int i = n2.Length - 1, j = 0; i >= 0; i--, j++)
            {
                arr2[j] = n2[i] - '0';
            }

            StringBuilder resultSb = new StringBuilder(n1.Length);

            for (int i = 0, t = 0; i < arr1.Length; i++)
            {
                t += arr1[i];
                if (i < arr2.Length) t -= arr2[i];
                resultSb.Append((t + 10) % 10);
                if (t < 0) t = -1;
                else t = 0;
            }

            char[] resultChars = resultSb.ToString().ToCharArray();
            Array.Reverse(resultChars);

            int leadingZeroCount = 0;
            while (leadingZeroCount < resultChars.Length && resultChars[leadingZeroCount] == '0')
            {
                leadingZeroCount++;
            }

            if (leadingZeroCount == resultChars.Length) return "0";

            return new string(resultChars, leadingZeroCount, resultChars.Length - leadingZeroCount);
        }

        /// <summary>
        /// 将两个正整数相乘【私有方法：可以确保 n1，n2均为正整数且不包含前导0，并且 n1 和 n2 的最大长度是 10000】
        /// </summary>
        /// <param name="n1">第一个正整数</param>
        /// <param name="n2">第二个正整数</param>
        /// <returns>n1 减 n2 的差值</returns>
        private static string MulPositive(string n1, string n2)
        {
            // TODO 正整数相乘
            return "";
        }

        /// <summary>
        /// 高精度整数相加【支持负数，不支持前导零】
        /// </summary>
        /// <param name="n1">第一个整数</param>
        /// <param name="n2">第二个整数</param>
        /// <returns>整数相加的和</returns>
        public static string Add(string n1, string n2)
        {
            // 非合法整数返回空
            if (!ValidatorUtil.IsValidNumber(n1) || !ValidatorUtil.IsValidNumber(n2))
            {
                return "";
            }

            // 限制长度 ≤ 10,000 字符
            if (n1.Length > 10_000 || n2.Length > 10_000)
            {
                return "";
            }

            // 0值快速返回
            if (n1 == "0") return n2;
            if (n2 == "0") return n1;

            // 到此，n1，n2只能是正整数或负整数

            // n1>0, n2>0 → 直接相加
            if (ValidatorUtil.IsValidPositiveNumber(n1) && ValidatorUtil.IsValidPositiveNumber(n2))
            {
                return AddPositive(n1, n2);
            }

            // n1>0, n2<0 → 绝对值相减
            if (ValidatorUtil.IsValidPositiveNumber(n1) && !ValidatorUtil.IsValidPositiveNumber(n2))
            {
                string absN2 = n2.Substring(1); // n2 是负数，截取后为绝对值
                int compareResult = Compare(n1, absN2);
                if (compareResult > 0) return SubPositive(n1, absN2);
                if (compareResult < 0) return "-" + SubPositive(absN2, n1);
                return "0";
            }

            // n1<0, n2>0 → 绝对值相减
            if (!ValidatorUtil.IsValidPositiveNumber(n1) && ValidatorUtil.IsValidPositiveNumber(n2))
            {
                string absN1 = n1.Substring(1); // n1 是负数，截取后为绝对值
                int compareResult = Compare(absN1, n2);
                if (compareResult > 0) return "-" + SubPositive(absN1, n2);
                if (compareResult < 0) return SubPositive(n2, absN1);
                return "0";
            }

            // n1<0, n2<0 → 绝对值相加后加负号
            string abs1 = n1.Substring(1); // n1 是负数，截取后为绝对值
            string abs2 = n2.Substring(1); // n2 是负数，截取后为绝对值
            return "-" + AddPositive(abs1, abs2);
        }

        /// <summary>
        /// 用一个整数减去另一个整数【支持负数，不支持前导零】
        /// </summary>
        /// <param name="n1">第一个整数</param>
        /// <param name="n2">第二个整数</param>
        /// <returns>n1-n2的结果</returns>
        public static string Sub(string n1, string n2)
        {
            if (!ValidatorUtil.IsValidNumber(n1) || !ValidatorUtil.IsValidNumber(n2))
            {
                return "";
            }

            // 限制长度 ≤ 10,000 字符
            if (n1.Length > 10_000 || n2.Length > 10_000)
            {
                return "";
            }

            if (n1 == "0")
            {
                if (n2[0] == '-')
                {
                    return n2.Substring(1);
                }

                if (n2 == "0")
                {
                    return "0";
                }

                return "-" + n2;
            }

            if (n2 == "0")
            {
                return n1;
            }

            // 到此，n1，n2只能是正整数或负整数

            // n1>0, n2>0
            if (ValidatorUtil.IsValidPositiveNumber(n1) && ValidatorUtil.IsValidPositiveNumber(n2))
            {
                int compare = Compare(n1, n2);
                if (compare > 0) return SubPositive(n1, n2);
                if (compare < 0) return "-" + SubPositive(n2, n1);
                return "0";
            }

            // n1>0, n2<0
            if (ValidatorUtil.IsValidPositiveNumber(n1) && !ValidatorUtil.IsValidPositiveNumber(n2))
            {
                string absN2 = n2.Substring(1); // n2 是负数，截取后为绝对值
                return Add(n1, absN2);
            }

            // n1<0, n2>0
            if (!ValidatorUtil.IsValidPositiveNumber(n1) && ValidatorUtil.IsValidPositiveNumber(n2))
            {
                string absN1 = n1.Substring(1); // n1 是负数，截取后为绝对值
                return "-" + Add(absN1, n2);
            }

            // n1<0, n2<0
            string abs1 = n1.Substring(1); // n1 是负数，截取后为绝对值
            string abs2 = n2.Substring(1); // n2 是负数，截取后为绝对值
            int compareResult = Compare(abs2, abs1);
            if (compareResult > 0) return SubPositive(abs2, abs1);
            if (compareResult < 0) return "-" + SubPositive(abs1, abs2);
            return "0";
        }
    }
}
