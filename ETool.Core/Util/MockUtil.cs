using System.Collections.Generic;

namespace ETool.Core.Util
{
    /// <summary>
    /// 模拟数据工具类
    /// </summary>
    public static class MockUtil
    {
        #region 生成模拟的 11 位手机号码

        /// <summary>
        /// 生成模拟的 11 位手机号码
        /// </summary>
        /// <returns>模拟生成的 11 位手机号码</returns>
        public static string MockPhoneNumber()
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

        #endregion

        #region 生成模拟的中文用户名

        private static readonly List<string> FirstUsernameList = new List<string>
        {
            "迷人", "美丽", "巨大", "可爱", "狡猾", "坚定", "有活力", "极好", "快速", "不错", "明亮", "干净", "帅气", "稳固", "特别", "整洁",
            "华丽", "伟大", "英俊", "炽热", "善良", "诚实", "战略性", "神秘", "开心", "耐心", "漂亮", "富有", "秘密", "聪明", "强大", "智慧"
        };

        private static readonly List<string> LastUsernameList = new List<string>
        {
            "苹果", "鳄梨", "香蕉", "黑莓", "蓝莓", "胡萝卜", "樱桃", "椰子", "葡萄", "柠檬", "莴苣", "芒果", "梨",
            "洋葱", "橙子", "木瓜", "桃子", "菠萝", "覆盆子", "土豆", "南瓜", "草莓", "番茄", "甜瓜", "蘑菇", "西兰花"
        };

        /// <summary>
        /// 生成模拟的中文用户名
        /// </summary>
        /// <returns>模拟生成的中文用户名</returns>
        public static string MockChineseUsername()
        {
            int idx1 = RandomUtil.GetRandomInt(0, FirstUsernameList.Count - 1);
            int idx2 = RandomUtil.GetRandomInt(0, LastUsernameList.Count - 1);
            return $"{FirstUsernameList[idx1]}的{LastUsernameList[idx2]}";
        }

        #endregion
    }
}
