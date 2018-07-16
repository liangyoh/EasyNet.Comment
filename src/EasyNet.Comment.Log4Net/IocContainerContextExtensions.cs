using EasyNet.Comment.Context;
using EasyNet.Comment.Logging;
using EasyNet.Comment.Serializing;

namespace EasyNet.Comment.Log4Net
{
    public static class IocContainerContextExtensions
    {
        /// <summary>Use Log4Net as the logger.
        /// </summary>
        /// <returns></returns>
        public static IocContainerContext UseLog4Net(this IocContainerContext configuration)
        {
            return UseLog4Net(configuration, "log4net.config");
        }
        /// <summary>Use Log4Net as the logger.
        /// </summary>
        /// <returns></returns>
        public static IocContainerContext UseLog4Net(this IocContainerContext configuration, string configFile, string loggerRepository = "NetStandardRepository")
        {
            configuration.Register<ILoggerFactory, Log4NetLoggerFactory>(new Log4NetLoggerFactory(configFile, loggerRepository));
            return configuration;
        }


    }
}
