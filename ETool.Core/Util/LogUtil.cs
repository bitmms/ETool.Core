using System;
using System.Collections.Generic;

namespace ETool.Core.Util
{
    /// <summary>
    /// 日志工具类
    /// </summary>
    public class LogUtil
    {
        /// <summary>
        /// 定义日志类型枚举，区分不同级别的日志
        /// </summary>
        public enum LogType
        {
            Info,
            Warn,
            Error
        }

        /// <summary>
        /// 定义日志处理委托，用于封装日志输出的行为逻辑
        /// </summary>
        /// <param name="text">日志内容文本</param>
        /// <param name="logType">日志类型</param>
        public delegate void LogHandler(string text, LogType logType);

        /// <summary>
        /// 日志类型与控制台输出颜色的映射关系
        /// </summary>
        private static readonly Dictionary<LogType, ConsoleColor> LogTypeColorMap = new Dictionary<LogType, ConsoleColor>
        {
            { LogType.Info, ConsoleColor.Green },
            { LogType.Warn, ConsoleColor.Yellow },
            { LogType.Error, ConsoleColor.Red },
        };

        /// <summary>
        /// 默认日志处理器：将日志以带颜色、时间戳和级别的方式输出到控制台。
        /// </summary>
        private static readonly LogHandler DefaultLogHandler = (text, logType) =>
        {
            if (StrUtil.IsNull(text))
            {
                text = "";
            }

            ConsoleColor originalColor = Console.ForegroundColor;
            try
            {
                if (LogTypeColorMap.ContainsKey(logType))
                {
                    Console.ForegroundColor = LogTypeColorMap[logType];
                }

                var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string level = StrUtil.ToUpperLetter(logType.ToString());
                string logFormatString = $"[{timestamp}] {$"[{level}]",-7} {text}";
                Console.WriteLine(logFormatString);
            }
            catch
            {
                // ignored
            }
            finally
            {
                try
                {
                    Console.ForegroundColor = originalColor;
                }
                catch
                {
                    // ignored
                }
            }
        };

        /// <summary>
        /// 线程锁
        /// </summary>
        private static readonly object SLock = new object();

        /// <summary>
        /// 当前生效的日志处理委托
        /// </summary>
        private static LogHandler _logHandler = DefaultLogHandler;

        /// <summary>
        /// 内部的日志记录方法，负责加锁并调用当前日志委托
        /// </summary>
        /// <param name="text">日志内容</param>
        /// <param name="logType">日志类型</param>
        private static void WriteLogCore(string text, LogType logType)
        {
            // 加锁目的：安全的执行委托
            lock (SLock)
            {
                _logHandler?.Invoke(text, logType);
            }
        }

        /// <summary>
        /// 替换日志处理委托【可用于将日志重定向到文件、网络或其他输出目标】【线程安全】
        /// </summary>
        /// <param name="logHandler"></param>
        public static void SetCurrentLogHandler(LogHandler logHandler)
        {
            if (logHandler == null)
            {
                return;
            }

            // 加锁目的：安全的更新委托，避免正在使用之前的委托输出日志时修改委托引发的异常情况
            lock (SLock)
            {
                _logHandler = logHandler;
            }
        }

        /// <summary>
        /// 输出 Info 日志
        /// </summary>
        /// <param name="text">待输出的日志文本</param>
        public static void Info(string text) => WriteLogCore(text, LogType.Info);

        /// <summary>
        /// 输出 Warn 日志
        /// </summary>
        /// <param name="text">待输出的日志文本</param>
        public static void Warn(string text) => WriteLogCore(text, LogType.Warn);

        /// <summary>
        /// 输出 Error 日志
        /// </summary>
        /// <param name="text">待输出的日志文本</param>
        public static void Error(string text) => WriteLogCore(text, LogType.Error);
    }
}
