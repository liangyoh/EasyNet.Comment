using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyNet.Comment.Context;
using EasyNet.Comment.Repository;

namespace EasyNet.Comment.Repository
{
    public static class IocContainerContextExtensions
    {
        public static IocContainerContext UseRepository(this IocContainerContext configuration)
        {
            configuration.RegisterType(typeof(IRepository<>), typeof(RepositoryInvoker<>));
            return configuration;
        }
    }
}
