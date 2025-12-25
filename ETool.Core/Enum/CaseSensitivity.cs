namespace ETool.Core.Enum
{
    /// <summary>
    /// 大小写敏感类型枚举（仅处理26个英文字母的大小写，其他字符原样保留）
    /// </summary>
    public enum CaseSensitivity
    {
        /// <summary>
        /// 严格区分所有字符（包括英文字母大小写）
        /// </summary>
        CaseSensitive,

        /// <summary>
        /// 仅忽略26个英文字母的大小写，其他字符严格匹配
        /// </summary>
        CaseIgnore
    }
}
