using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeiFei.Log
{
    /// <summary>
    /// Log的配置文件
    /// </summary>
    internal class Configuration
    {
        /// <summary>
        /// Info级别日志的目录
        /// </summary>
        private const string INFO = "Info";

        /// <summary>
        /// Debug级别日志的目录
        /// </summary>
        private const string DEBUG = "Debug";

        /// <summary>
        /// Warn级别日志的目录
        /// </summary>
        private const string WARN = "Warn";

        /// <summary>
        /// ERROR级别日志的目录
        /// </summary>
        private const string ERROR = "Error";

        /// <summary>
        /// FATAL级别日志的目录
        /// </summary>
        private const string FATAL = "Fatal";

        /// <summary>
        /// 加载配置
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
        /// <returns>数据流</returns>
        public static System.IO.Stream LoadConfiguration(string loggerName, string dirPath, bool debugEnable = true, bool infoEnable = true, bool warnEnable = false, bool errorEnable = true, bool fatalEnable = false, int rollBackups = 10, int maxSize = 10)
        {
            //配置
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<configuration>");
            strBuilder.Append("<!--添加自定义节点：log4net type：解析类名，程序集名(log4net.dll)-->");
            strBuilder.Append("<configSections>");
            strBuilder.Append("<section name = \"log4net\" type = \"log4net.Config.Log4NetConfigurationSectionHandler, log4net\" />");
            strBuilder.Append("</configSections>");

            strBuilder.Append("<!--相关配置说明参见Log4_ReadMe.txt-->");
            strBuilder.Append("<log4net>");
            strBuilder.Append("<!--按照日志级别输出到不同的路径-->");
            strBuilder.AppendFormat("<logger name = \"{0}\" additivity = \"false\">", loggerName);
            strBuilder.Append("<level value = \"All\" />");
            strBuilder.Append("<appender-ref ref= \"InfoLog\" />");
            strBuilder.Append("<appender-ref ref= \"DebugLog\" />");
            strBuilder.Append("<appender-ref ref= \"WarnLog\" />");
            strBuilder.Append("<appender-ref ref= \"ErrorLog\" />");
            strBuilder.Append("<appender-ref ref= \"FatalLog\" />");
            strBuilder.Append("</logger>");

            //基础
            if (infoEnable)
            {
                strBuilder.Append("<!--一般日志-->");
                strBuilder.Append(CreateAppender(INFO, dirPath, rollBackups, maxSize));
            }

            //调试
            if (debugEnable)
            {
                strBuilder.Append("<!--调试日志-->");
                strBuilder.Append(CreateAppender(DEBUG, dirPath, rollBackups, maxSize));
            }

            //警告
            if (warnEnable)
            {
                strBuilder.Append("<!--警告日志-->");
                strBuilder.Append(CreateAppender(WARN, dirPath, rollBackups, maxSize));
            }

            //错误
            if (errorEnable)
            {
                strBuilder.Append("<!--一般错误-->");
                strBuilder.Append(CreateAppender(ERROR, dirPath, rollBackups, maxSize));
            }

            //致命错误
            if (fatalEnable)
            {
                strBuilder.Append("<!--致命错误-->");
                strBuilder.Append(CreateAppender(FATAL, dirPath, rollBackups, maxSize));
            }

            strBuilder.Append("</log4net> ");
            strBuilder.Append("</configuration> ");

            //返回
            byte[] bytes = Encoding.UTF8.GetBytes(strBuilder.ToString());
            System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// 创建对应的Appender
        /// </summary>
        /// <param name="logMode">日志模式</param>
        /// <param name="dirPath">存储的目录</param>
        /// <param name="rollBackups">最多可备份的文件个数</param>
        /// <param name="maxSize">每个文件的最大大小</param>
        /// <returns>Appender</returns>
        public static string CreateAppender(string logMode, string dirPath, int rollBackups, int maxSize)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<!--定义输出到文件中，按照日期和大小自动切换文件-->");
            strBuilder.AppendFormat("<appender name = \"{0}Log\" type = \"log4net.Appender.RollingFileAppender\" >", logMode);

            strBuilder.Append("<!--路径-->");
            strBuilder.AppendFormat("<file value = \"{0}\" />", dirPath + "\\" + logMode + "\\");

            strBuilder.Append("<!--是否追加到文件,默认为true，通常无需设置-->");
            strBuilder.AppendFormat("<appendToFile value = \"true\" />");

            strBuilder.Append("<!--按照何种方式产生多个日志文件(日期[Date],文件大小[Size],混合[Composite])-->");
            strBuilder.AppendFormat("<rollingStyle value = \"Composite\" />");

            strBuilder.Append("<!--多线程时采用最小锁定-->");
            strBuilder.AppendFormat("<lockingModel type = \"log4net.Appender.FileAppender+MinimalLock\" />");

            strBuilder.Append("<!--此处按日期产生文件，文件名固定。注意&quot; 的位置-->");
            strBuilder.AppendFormat("<datePattern value = \"yyyyMMdd_&quot;{0}.txt&quot;\" />", logMode);

            strBuilder.Append("<!--日志文件名是否为静态，是否只写入到一个文件中-->");
            strBuilder.AppendFormat("<staticLogFileName value = \"false\" />");

            strBuilder.Append("<!--最多产生的日志文件数，超过则只保留最新的n个。设定值value=\"－1\"为不限文件数-->");
            strBuilder.AppendFormat("<maxSizeRollBackups value = \"{0}\" />", rollBackups);

            strBuilder.Append("<!--每个文件的大小。只在混合方式与文件大小方式下使用。");
            strBuilder.Append("超出大小后在所有文件名后自动增加正整数重新命名，数字最大的最早写入。");
            strBuilder.Append("可用的单位: KB | MB | GB。不要使用小数, 否则会一直写入当前日志--> ");
            strBuilder.AppendFormat("<maximumFileSize value = \"{0}MB\" />", maxSize);

            strBuilder.Append("<!--将日志按照等级进行过滤-->");
            strBuilder.AppendFormat("<filter type = \"log4net.Filter.LevelRangeFilter\" >");
            strBuilder.AppendFormat("<param name = \"LevelMin\" value = \"{0}\" />", logMode);
            strBuilder.AppendFormat("<param name = \"LevelMax\" value = \"{0}\" />", logMode);
            strBuilder.AppendFormat("</filter>");

            strBuilder.Append("<!--按照等级过滤时必须增加此行才生效-->");
            strBuilder.AppendFormat("<filter type = \"log4net.Filter.DenyAllFilter\" />");

            strBuilder.Append("<!--布局（向用户显示最后经过格式化的输出信息）-->");
            strBuilder.Append("<!--% m(message):输出的日志消息，如ILog.Debug(…)输出的一条消息");
            strBuilder.Append("% n(new line):换行");
            strBuilder.Append("% d(datetime):输出当前语句运行的时刻");
            strBuilder.Append("% r(run time):输出程序从运行到执行到当前语句时消耗的毫秒数");
            strBuilder.Append("% t(thread id):当前语句所在的线程ID");
            strBuilder.Append("% p(priority): 日志的当前优先级别，即DEBUG、INFO、WARN…等");
            strBuilder.Append("% c(class):当前日志对象的名称，例如：");
            strBuilder.Append("% L：输出语句所在的行号 ");
            strBuilder.Append("% F：输出语句所在的文件名 ");
            strBuilder.Append("% -数字：表示该项的最小长度，如果不够，则用空格填充-->");
            strBuilder.AppendFormat("<layout type = \"log4net.Layout.PatternLayout\" >");
            strBuilder.Append("<conversionPattern value = \"%date [%thread] %message %newline\" />");
            strBuilder.AppendFormat("</layout>");
            strBuilder.AppendFormat("</appender>");
            return strBuilder.ToString();
        }
    }
}
