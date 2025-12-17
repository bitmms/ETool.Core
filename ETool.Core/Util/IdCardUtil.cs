using System;
using System.Collections.Generic;
using System.Globalization;

namespace ETool.Core.Util
{
    /// <summary>
    /// 身份证号码工具类【中国大陆身份证号码：18位、15位】
    /// </summary>
    /// <remarks>参考标准：<see href="https://openstd.samr.gov.cn/bzgk/gb/newGbInfo?hcno=080D6FBF2BB468F9007657F26D60013E">《GB11643-1999》</see></remarks>
    public static class IdCardUtil
    {
        // 省份编码
        private static readonly HashSet<string> MainlandProvinceCodes = new HashSet<string>()
        {
            "11", "12", "13", "14", "15", // 华北
            "21", "22", "23", // 东北
            "31", "32", "33", "34", "35", "36", "37", // 华东
            "41", "42", "43", "44", "45", "46", // 华南
            "50", "51", "52", "53", "54", // 西南
            "61", "62", "63", "64", "65", // 西北
        };

        // 18位身份证有效省份编码（含大陆+港澳台）【注意：港澳台地区有自身独立的身份证件体系，大陆为便利港澳台居民在内地生活，推出了「港澳台居民居住证」（格式兼容身份证（18位+校验码））】
        private static readonly HashSet<string> Valid18IdProvinceCodes = new HashSet<string>(MainlandProvinceCodes)
        {
            "71", // 台湾
            "81", // 香港
            "82", // 澳门
        };

        // 加权因子（18位身份证前17位的加权系数）
        private static readonly int[] CheckWeights = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };

        // 校验码映射表（余数0-10对应校验码）
        private static readonly char[] CheckCodes = { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };

        /// <summary>
        /// 检验指定字符串是否符合中国 18 位身份证的格式规范
        /// </summary>
        /// <param name="s">待校验的字符串</param>
        /// <returns>如果字符串符合返回 true，否则返回 false</returns>
        public static bool IsValidChinaIdCard18(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length != 18)
            {
                return false;
            }

            // 前17位必须是数字
            for (var i = 0; i < 17; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                {
                    return false;
                }
            }

            // 第18位：数字或 X/x
            if (!(s[17] == 'x' || s[17] == 'X' || s[17] >= '0' && s[17] <= '9'))
            {
                return false;
            }

            // 省份码校验
            if (!Valid18IdProvinceCodes.Contains(s.Substring(0, 2)))
            {
                return false;
            }

            // 出生日期格式校验
            if (!DateTime.TryParseExact(s.Substring(6, 8), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var datetime))
            {
                return false;
            }

            // 合理出生日期范围：假定拥有 18 位身份证号码的人的出生日期为：1900-01-01 ~ Today + 1
            if (datetime < new DateTime(1900, 1, 1) || datetime > DateTime.Today.AddDays(1))
            {
                return false;
            }

            // 校验码计算
            var sum = 0;
            for (var i = 0; i < 17; i++)
            {
                sum += (s[i] - '0') * CheckWeights[i];
            }

            return CheckCodes[sum % 11] == CharUtil.ToUpperLetter(s[17]);
        }
    }
}
