using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyNet.Comment.Context;
using EasyNet.Comment.Dapper;
using EasyNet.Comment.Repository;

namespace EasyNet.Comment.Dapper
{
    public static class IocContainerContextExtensions
    {
        public static IocContainerContext UseDapper(this IocContainerContext configuration)
        {
            configuration.Register<IDapper, DapperInstance>(new DapperInstance());
            return configuration;
        }
    }
}
