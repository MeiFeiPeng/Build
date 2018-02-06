using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiFei.Log
{
    #region 日志级别枚举

    /// <summary>
    /// 日志级别
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 一般日志
        /// </summary>
        Info,

        /// <summary>
        /// 调试日志
        /// </summary>
        Debug,

        /// <summary>
        /// 警告日志
        /// </summary>
        Warn,

        /// <summary>
        /// 错误日志
        /// </summary>
        Error,

        /// <summary>
        /// 致命错误
        /// </summary>
        Fatal
    }

    #endregion

    /// <summary>
    /// 日志输出基类，默认只启用Info、Debug、Error三种日志
    /// </summary>
    public abstract class LogBase
    {
        /// <summary>
        /// Log4日志接口
        /// </summary>
        protected log4net.ILog m_Log4 = null;

        /// <summary>
        /// 调试日志可用性
        /// </summary>
        protected bool m_DebugEnable;

        /// <summary>
        /// 基础日志可用性
        /// </summary>
        protected bool m_InfoEnable;

        /// <summary>
        /// 警告日志可用性
        /// </summary>
        protected bool m_WarnEnable;

        /// <summary>
        /// 错误日志可用性
        /// </summary>
        protected bool m_ErrorEnable;

        /// <summary>
        /// 致命错误日志可用性
        /// </summary>
        protected bool m_FatalEnable;

        /// <summary>
        /// 构造函数，默认只启用Info、Debug、Error三种日志
        /// </summary>
        /// <param name="loggerName">日志的名称</param>
        /// <param name="dirPath">日志的目录</param>
        /// <param name="debugEnable">Debug日志可用性</param>
        /// <param name="infoEnable">Info日志可用性</param>
        /// <param name="warnEnable">警告日志可用性</param>
        /// <param name="errorEnable">错误日志可用性</param>
        /// <param name="fatalEnable">致命错误日志可用性</param>
        /// <param name="rollBackups">最大可备份的文件个数</param>
        /// <param name="maxSize">单个文件的最大大小</param>
        public LogBase(string loggerName, string dirPath, bool debugEnable = true, bool infoEnable = true, bool warnEnable = false, bool errorEnable = true, bool fatalEnable = false, int rollBackups = 10, int maxSize = 50)
        {
            //缓存
            m_DebugEnable = debugEnable;
            m_InfoEnable = infoEnable;
            m_WarnEnable = warnEnable;
            m_ErrorEnable = errorEnable;
            m_FatalEnable = fatalEnable;

            //初始化Log4
            var stream = Configuration.LoadConfiguration(loggerName, dirPath, debugEnable, infoEnable, warnEnable, errorEnable, fatalEnable, rollBackups, maxSize);
            log4net.Config.XmlConfigurator.Configure(stream);
            m_Log4 = log4net.LogManager.GetLogger(loggerName);

            //释放
            stream.Dispose();
        }

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="msg">日志</param>
        /// <param name="ex">异常，默认不输出异常</param>
        public void WriteLog(LogLevel level, string msg, Exception ex = null)
        {
            //根据不同级别日志进行输出
            switch (level)
            {
                //一般日志
                case LogLevel.Info:
                    if (!m_InfoEnable)
                        throw new Exception("如果要输出Info日志,请在实例化时指定InfoEnable为True");

                    if (ex == null)
                        m_Log4.Info(msg);
                    else
                        m_Log4.Info(msg, ex);
                    break;

                //调试日志
                case LogLevel.Debug:
                    if (!m_InfoEnable)
                        throw new Exception("如果要输出Debug日志,请在实例化时指定DebugEnable为True");

                    if (ex == null)
                        m_Log4.Debug(msg);
                    else
                        m_Log4.Debug(msg, ex);
                    break;

                //警告日志
                case LogLevel.Warn:
                    if (!m_InfoEnable)
                        throw new Exception("如果要输出Warn日志,请在实例化时指定WarnEnable为True");

                    if (ex == null)
                        m_Log4.Warn(msg);
                    else
                        m_Log4.Warn(msg, ex);
                    break;

                //错误日志
                case LogLevel.Error:
                    if (!m_InfoEnable)
                        throw new Exception("如果要输出Error日志,请在实例化时指定ErrorEnable为True");

                    if (ex == null)
                        m_Log4.Error(msg);
                    else
                        m_Log4.Error(msg, ex);
                    break;

                //致命错误
                case LogLevel.Fatal:
                    if (!m_InfoEnable)
                        throw new Exception("如果要输出Fatal日志,请在实例化时指定FatalEnable为True");

                    if (ex == null)
                        m_Log4.Fatal(msg);
                    else
                        m_Log4.Fatal(msg, ex);
                    break;
            }
        }
    }
}
