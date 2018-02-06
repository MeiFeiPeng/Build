using FeiFei.Log;
using System.IO;

namespace FeiFei.Demo
{
    /// <summary>
    /// 日志输出帮助类
    /// </summary>
    class LogHelper : LogBase
    {
        #region 构造函数与单实例

        private static LogHelper m_Instance = null;
        /// <summary>
        /// 日志输出帮助类
        /// </summary>
        public static LogHelper Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new LogHelper();
                return m_Instance;
            }
        }

        /// <summary>
        /// 私有构造保证单实例
        /// </summary>
        /// <param name="loggerName">日志名称</param>
        /// <param name="dirPath">存储的目录</param>
        private LogHelper(string loggerName = "FeiFei", string dirPath = @"Log\FeiFei\") : base(loggerName, dirPath)
        { }

        #endregion
    }
}
