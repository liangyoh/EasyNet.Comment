using EasyNet.Comment;
using EasyNet.Comment.Context;
using EasyNet.Comment.Autofac;
using EasyNet.Comment.Logging;
using EasyNet.Comment.Dapper;
using EasyNet.Comment.Repository;
using EasyNet.Comment.Ioc;
using EasyNet.Comment.Log4Net;

namespace EasyNet.Comment.Test
{
    class Program
    {
        static ILogger _logger;

        static void Main(string[] args)
        {
            IocContainerContext
                .Create()
                .UserAutofac()
                .UseLog4Net()
                .UseRepository()
                .UseDapper()
                .BuildContainer();

            _logger = IocContainerInvoker.Resolve<ILoggerFactory>().Create(typeof(Program).Name);
            _logger.Debug("This is a Debug message.");
        }
    }
}
