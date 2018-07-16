using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using EasyNet.Comment.Ioc;
using EasyNet.Comment.Logging;

namespace EasyNet.Comment.Context
{
    public class IocContainerContext
    {
        public static IocContainerContext Instance { get; private set; }

        private IocContainerContext() { }

        public static IocContainerContext Create()
        {
            Instance = new IocContainerContext();
            return Instance;
        }

        public IocContainerContext Register<TService, TImplementer>(string serviceName = null, LifeStyle lifeStyle =  LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            IocContainerInvoker.Register<TService, TImplementer>(serviceName, lifeStyle);
            return this;
        }

        public IocContainerContext Register<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            IocContainerInvoker.RegisterInstance<TService, TImplementer>(instance, serviceName);
            return this;
        }


        public IocContainerContext RegisterCommonComponents()
        {
            //SetDefault<ILoggerFactory, EmptyLoggerFactory>();
            //SetDefault<IBinarySerializer, DefaultBinarySerializer>();
            //SetDefault<IJsonSerializer, NotImplementedJsonSerializer>();
            //SetDefault<IScheduleService, ScheduleService>(null, LifeStyle.Transient);
            //SetDefault<IMessageFramer, LengthPrefixMessageFramer>(null, LifeStyle.Transient);
            //SetDefault<IOHelper, IOHelper>();
            //SetDefault<IPerformanceService, DefaultPerformanceService>(null, LifeStyle.Transient);
            return this;
        }


        public IocContainerContext RegisterUnhandledExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var logger = IocContainerInvoker.Resolve<ILoggerFactory>().Create(GetType().FullName);
                logger.ErrorFormat("Unhandled exception: {0}", e.ExceptionObject);
            };
            return this;
        }
        public IocContainerContext BuildContainer()
        {
            IocContainerInvoker.Build();
            return this;
        }
    }
}
