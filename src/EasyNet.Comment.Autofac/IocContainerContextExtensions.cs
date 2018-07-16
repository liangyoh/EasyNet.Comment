using Autofac;
using EasyNet.Comment.Context;
using EasyNet.Comment.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNet.Comment.Autofac
{
    public static class IocContainerContextExtensions
    {
        public static IocContainerContext UserAutofac(this IocContainerContext iocContainerContext)
        {
            return UserAutofac(iocContainerContext, new ContainerBuilder());
        }
        public static IocContainerContext UserAutofac(this IocContainerContext iocContainerContext, ContainerBuilder containerBuilder)
        {
            IocContainerInvoker.SetContainer(new AutofacObjectContainer(containerBuilder));
            return iocContainerContext;
        }

    }
}
